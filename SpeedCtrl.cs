using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpeedCtrl : MonoBehaviour
{
    public GameObject stageCreator;
    public Slider SpeedSlider;
    private int changeSpeed = 0;

    //Start is called before the first frame update
    public void Start()
    {
        changeSpeed = (int)SpeedSlider.value;
        stageCreator.GetComponent<StageGenerator>().GetXSpeed(changeSpeed);
    }

    //プレイヤーのコンポーネントを取得してGetXSpeedに本スクリプトのSpeedを引数として渡す
    //問題点として汎用的ではない（プレイヤー以外に使えない）
    public void GetSpeedVal()
    {
        changeSpeed = (int)SpeedSlider.value;
        stageCreator.GetComponent<StageGenerator>().GetXSpeed(changeSpeed);
    }

}
