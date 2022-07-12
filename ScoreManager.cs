using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    // スコア
    private int score = 0;
    int hightScore;
    int tempScore;
    private Text scoreLabel;

    // タイマー
    [SerializeField]
    private float maxTime = 60;
    float second;
    public Text timerText;

    void Start()
    {
        hightScore = ES3.Load<int>("count", defaultValue: 0);
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        scoreLabel.text = "SCORE：" + score;

        timerText.text = "{maxTime}";
    }

    private void Update()
    {
        if (second >= 0) 
        { 
            maxTime -= Time.deltaTime;
            second = maxTime;
            timerText.text = second.ToString("f1");
            Scoring();
        }
        
        // タイマーが0になったらゲームクリア（ゲームオーバーシーン）
        else
        {
            Scoring();
            Invoke("isClear", 0.4f);
        }
        
    }

    public void Scoring()
    {
        tempScore = score;
        ES3.Save<int>("beforecount", tempScore);

        if (hightScore <= score)
        {
            hightScore = score;
            ES3.Save<int>("count", hightScore);
        }
        else
        {
            ES3.Save<int>("count", hightScore);
        }
    }

    // スコアを増加させるメソッド
    // 外部からアクセスするためpublicで定義する
    public void AddScore(int amount)
    {
        score += amount;
        scoreLabel.text = "SCORE：" + score;
    }

    void isClear()
    {
        SceneManager.LoadScene("Clear");
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    AddScore(score);
    //}
    }