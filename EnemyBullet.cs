using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D BltRig = null;
    public int Speed;

    public GameObject breakEffect;

    //public void GetXSpeed(int newSpeed)
    //{
    //    Speed = newSpeed + 1;

    //    Debug.Log("newSpeed�F" + newSpeed);
    //}

    // Start is called before the first frame update
    void Start()
    {
        BltRig.velocity = transform.right * -Speed;
    }

    // 今回の実装ではIsTriggerを採用
    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //    // EnemyEnemyタグを持つものにあたった際に起動（消滅）
    //     if (collision.gameObject.CompareTag("Enemy"))
    //     {
    //         Destroy(this.gameObject);
    //     }
    // }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Playerタグを持つものにあたった際に起動（消滅）
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
        // Mapタグを持つものにあたった際に起動（消滅）
        else if (collider.gameObject.CompareTag("Map"))
        {
            Destroy(this.gameObject);
        }
        else if(collider.gameObject.CompareTag("Bullets"))
        {
            Destroy(this.gameObject);
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

    private void OnBecameInvisible()
    {
        // カメラの外に出たら消滅
        Destroy(gameObject);
    }
}