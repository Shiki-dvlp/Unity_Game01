using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //画面遷移してもオブジェクトが壊れないようにする
        DontDestroyOnLoad (this);
    }
}
