using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGenerator : MonoBehaviour
{
    public List<GameObject> stage;
    GameObject[] step = new GameObject[10];

    [SerializeField]
    private float disappear = -10;
    [SerializeField]
    private float respawn = 30;

    //public GameObject GameOver;
    public float speed = 10;

    public void GetXSpeed(float newSpeed)
    {
        speed = newSpeed;

    }

    void Start()
    {
        // 配列の中身をゲームスタート時にランダム取得する
        for (int i = 0; i < step.Length; i++)
        {
            int count = Random.Range(0, step.Length);
            step[i] = Instantiate(stage[count], new Vector3(10 * i, 0, 0), Quaternion.identity);
        }
    }
    // 無限ランでStageが動く場合
    void Update()
    {
        // stepの配列分繰り返す
        for (int i = 0; i < step.Length; i++)
        {
            // step配列内のオブジェクト時間経過とともにX軸マイナス方向（左）に移動
            step[i].gameObject.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            // オブジェクトがdisappearの指定位置まで移動したら
            if (step[i].gameObject.transform.position.x < disappear)
            {
                // 指定のrespawn位置に移動させる
                step[i].gameObject.transform.position = new Vector3(respawn, 0, 0);
            }
        }
    }
}

