using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class Recover : MonoBehaviour
{
    //Vector3クラスのrot変数
    private Vector3 rot;

    // Update is called once per frame
    void Update()
    {
        //rot変数に指定した座標に回転させる
        rot = transform.eulerAngles;

        //もしRキーを押した場合
        if (Input.GetKeyDown(KeyCode.R))
        {
            //アタッチしたオブジェクトの指定した座標までrot.yを回転させる
            transform.eulerAngles = new Vector3(0, rot.y, 0);
        }
    }
}
