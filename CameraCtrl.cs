using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{
    [SerializeField]
    GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーオブジェクトの座標を取得
        Vector3 playerPos = Player.transform.position;

        // カメラの座標をプレイヤーオブジェクトのX軸のみ同じにする
        this.transform.position = new Vector3(playerPos.x + 3, 1,-10);
    }
}
