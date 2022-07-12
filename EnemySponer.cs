using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySponer : MonoBehaviour
{
    public GameObject[] EnemyPrefabs;   // エネミープレハブを格納
    private float time;                 // 出現タイミング
    private int number;                 // ランダムにする為
    public float spwn;

    // Start is called before the first frame update
    void Start()
    {
        time = Random.Range(1, 2);
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if(time <= 0.0f)
        {
            time = Random.Range(1, 3);
            number = Random.Range(0, EnemyPrefabs.Length);
            Instantiate(EnemyPrefabs[number],new Vector2(30,spwn),Quaternion.identity);
        }
    }
}
