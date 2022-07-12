using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverZone : MonoBehaviour
{
    // ステージ生成のオブジェクト
    [SerializeField]
    GameObject StageCreator;

    private float Speed = 0;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Playerがぶつかったら
        if (collider.gameObject.CompareTag("Player"))
        {
            Speed = 0;
            StageCreator.GetComponent<StageGenerator>().GetXSpeed(Speed);
            //Enemy.GetComponent<EnemyManager>().GetXSpeed(Speed);
            Invoke("ChangeScene", 2.0f);
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("Gameover");
    }

}
