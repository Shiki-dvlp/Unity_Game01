using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Restar : MonoBehaviour
{
    public Text bestScoreText;
    int bestScore;

    public Text beforeScoreText;
    int beforeScore;


    void Start()
    {
        bestScore = ES3.Load("count", defaultValue: 0);
        bestScoreText = bestScoreText.GetComponent<Text>();
        bestScoreText.text = bestScore.ToString();

        beforeScore = ES3.Load("beforecount", defaultValue: 0);
        beforeScoreText = beforeScoreText.GetComponent<Text>();
        beforeScoreText.text = beforeScore.ToString();
    }
}
