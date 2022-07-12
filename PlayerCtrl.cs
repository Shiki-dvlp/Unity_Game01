using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerCtrl : MonoBehaviour
{
    public AudioClip sound1;
    public AudioClip sound2;
    AudioSource audioSource;
    private Rigidbody2D rig = null;
    private Animator anim;


    //　ジャンプ関連
    private Vector2 velocity;
    public float Jump_Pow;
    public int Max_Jump_Count = 2;
    private int JumpCount = 0;
    // private bool Jump = false;
    [SerializeField]
    GameObject jumpButton;

    // 接地判定
    public GroundCheck ground;
    private bool isGround = false;

    // 射撃関連
    [SerializeField]
    GameObject bulletPrefab = null;
    private float rAttackTimer;

    // 近接攻撃
    [SerializeField]
    GameObject Weapon = null;
    private float attackTimer;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        attackTimer = 0.0f;
        rAttackTimer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        attackTimer -= Time.deltaTime;
        rAttackTimer -= Time.deltaTime;
        //接地判定
        isJump();
        
        // 移動速度の可変処理（X軸のみ）
        //this.transform.position += new Vector3(xSpeed * Time.deltaTime,0, 0);
        // 近接攻撃
        isAttack();
        // 遠距離攻撃
        isrAttack();

    }

    void isAttack()
    {
        // 左クリックで弾を打つ
        if (/*CrossPlatformInputManager.GetButtonDown("Attack") == true || */Input.GetMouseButtonDown(0) && attackTimer < 0 )
        {
            anim.SetBool("DAttack_bool",true);
            anim.SetBool("Run_bool", false);
            anim.SetBool("Jump_bool", false);
            Weapon.SetActive(true);
            audioSource.PlayOneShot(sound1);
            StartCoroutine("AtStop");//コルーチンを実行
            // Instantiate(weaponPrefab, this.transform.position, this.transform.rotation);
            attackTimer = 0.3f;
        }
        else
        {
            anim.SetBool("DAttack_bool",false);
        }
    }
    IEnumerator AtStop()
    {
        yield return new WaitForSeconds(0.3f);
        Weapon.SetActive(false);
    }
    void isrAttack()
    {
        // 右クリックで弾を打つ
        if (/*CrossPlatformInputManager.GetButtonDown("rAttack") == true || */Input.GetMouseButtonDown(1) && rAttackTimer < 0 )
        {
            anim.SetBool("RAttack_bool",true);
            anim.SetBool("Run_bool", false);
            anim.SetBool("Jump_bool", false);
            audioSource.PlayOneShot(sound2);
            Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            rAttackTimer = 1.5f;
        }
        else
        {
            anim.SetBool("RAttack_bool",false);
        }
    }

    public void isJump()
    {
        isGround = ground.IsGround();
        if (/*JumpCount < Max_Jump_Count && CrossPlatformInputManager.GetButtonDown("Jump") || */Input.GetKeyDown("space"))
        {
            anim.SetBool("Jump_bool", true);
            anim.SetBool("Run_bool",false);

            // 落下の速度をゼロとしてもう一度ジャンプを行う（1回目と2回目のジャンプは同じ挙動となる）
            rig.velocity = Vector2.zero;

            // ジャンプ
            this.rig.AddForce(transform.up * Jump_Pow);

            JumpCount++;
            //Jump = false;
        }
        else
        {
            anim.SetBool("Jump_bool", false);
        }
        // 床の着地判定、着地時にジャンプカウントを0に戻す
        if (isGround == true)
        {
            anim.SetBool("Run_bool",true);
            anim.SetBool("Fall_bool",false);
            JumpCount = 0;
        }
        else if(isGround == false)
        {
            anim.SetBool("Fall_bool",true);
            anim.SetBool("Run_bool", false);
        }
    }
    // カメラから消えたらシーン移動（ゲームオーバー）
    private void OnBecameInvisible()
    {
        Invoke("ChangeScene", 0.5f);
    }

    void ChangeScene()
    {
        SceneManager.LoadScene("Gameover");
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        //Bulletsタグを持つものに当たった場合消滅
        if (collider.gameObject.CompareTag("EnemyAttack") || collider.gameObject.CompareTag("EnemyBullets") )
        {
            anim.SetBool("Death_bool", true);
            Invoke("ChangeScene", 0.5f);
        }
    }

}
