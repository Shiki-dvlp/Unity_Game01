using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D BltRig = null;
    [SerializeField]
    int Speed;

    //public void GetXSpeed(int newSpeed)
    //{
    //    Speed = newSpeed + 1;

    //    Debug.Log("newSpeed�F" + newSpeed);
    //}

    // Start is called before the first frame update
    void Start()
    {
        BltRig.velocity = transform.right * Speed;
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
        // Enemyタグを持つものにあたった際に起動（消滅）
        // if (collider.gameObject.CompareTag("Enemy"))
        // {
        //    Destroy(this.gameObject);
        // }
        // Mapタグを持つものにあたった際に起動（消滅）
        if (collider.gameObject.CompareTag("Map"))
        {
            Destroy(this.gameObject);
        }

    }

    private void OnBecameInvisible()
    {
        // カメラの外に出たら消滅
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
         
    }
}
