using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatEnemyManager : MonoBehaviour
{
    private Animator anim;
    [SerializeField]
    Rigidbody2D EnemyRig = null;
        //倒したときのエフェクト
    public GameObject breakEffect;

    // 移動速度
    [SerializeField]
    private float xSpeed = 0;

    // エネミーの消滅位置
    [SerializeField]
    private float DespawnPoint = -10;

    // エネミーの各スコア
    private ScoreManager scoreManaeger;
    public int scoreValue;

    // 索敵
    public SearchEnemy searchEnemy;
    private bool isSearch = false;

    [SerializeField]
    GameObject EnemyWeapon = null;
    private float attackTimer;

    GameObject player;
    GameObject hormingObj;
    public float ySpeed;

    //public void GetXSpeed(float newSpeed)
    //{
    //    xSpeed = newSpeed;

    //}
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        hormingObj = GameObject.Find("Enemy");
        EnemyRig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackTimer = 0.0f;
        // 「ScoreManagerオブジェクト」に付いている「ScoreManagerスクリプト」の情報を取得して「sm」の箱に入れる。
        scoreManaeger = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = Vector2.MoveTowards (this.transform.position,
                                                        new Vector2(this.transform.position.x,
                                                         player.transform.position.y), ySpeed * Time.deltaTime);
        attackTimer -= Time.deltaTime;
        isEAttack();
        // if (Input.GetMouseButtonDown(1) == true)
        // {
        //     // transformを取得
        //     Transform myTransform = this.transform;
        //     Vector3 pos = myTransform.position;

        //     pos.x -= 0.5f;

        //     myTransform.position = pos;
        // }
        EnemyRig.velocity = transform.right * -xSpeed;
        Despawn();
    }

    void isEAttack()
    {
        isSearch = searchEnemy.IsSearch();
        if (isSearch == true && attackTimer < 0 )
        {
            anim.SetBool("EAttack_bool",true);
            anim.SetBool("ERun_bool",false);
            EnemyWeapon.SetActive(true);
            StartCoroutine("AtStop");//コルーチンを実行
            attackTimer = 1.0f;
        }
        else
        {
            anim.SetBool("EAttack_bool",false);
            anim.SetBool("ERun_bool",true);
        }
    }
        IEnumerator AtStop()
    {
        yield return new WaitForSeconds(0.5f);
        EnemyWeapon.SetActive(false);
    }

        private void Despawn()
    {
        if (EnemyRig.transform.position.x < DespawnPoint)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Bulletsタグを持つものに当たった場合消滅
        if (collider.gameObject.CompareTag("Bullets"))
        {
            Destroy(gameObject);
            Destroy(collider.gameObject);
            // スコアマネージャーにスコアを渡す
            scoreManaeger.AddScore(scoreValue);
            GenerateEffect();
        }
        else if (collider.gameObject.CompareTag("Weapon"))
        {
            Destroy(gameObject);
            // スコアマネージャーにスコアを渡す
            scoreManaeger.AddScore(scoreValue);
            //エフェクトを発生させる
            GenerateEffect();
        }
    }

    void GenerateEffect()
    {
        //エフェクトを生成する
        GameObject effect = Instantiate(breakEffect) as GameObject;
        //エフェクトが発生する場所を決定する(敵オブジェクトの場所)
        effect.transform.position = gameObject.transform.position;
    }
    
}
