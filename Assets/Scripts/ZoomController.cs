using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ズーム機能
/// </summary>
public class ZoomController : MonoBehaviour
{
    //Camera型cam変数
    private Camera cam;
    //float型zoom変数
    private float zoom;
    //float型view変数
    private float view;

    // Start is called before the first frame update
    void Start()
    {
        //cam変数にCameraを取得
        cam = GetComponent<Camera>();
        //view変数にcam変数のfieldOfViewを代入する
        view = cam.fieldOfView;
    }

    // Update is called once per frame
    void Update()
    {
        //cam変数のfieldOfViewにvieew変数+zoom変数を加えた値を代入する
        cam.fieldOfView = view + zoom;

        // ズームアップの上限値を定める。
        //もしcam変数のfieldOfViewが20ｆ未満なら
        if (cam.fieldOfView < 20f) 
        {
            //20を代入する
            cam.fieldOfView = 20f;
        }
        //元の位置を定める
        //もしcamのfieldOfViewが60以上の場合
        if (cam.fieldOfView > 60)
        {
            //camのfieldOfViewに60を代入する
            cam.fieldOfView = 60f;
        }

        // 実際にどのキーを割り当てるかは自由です。
        //もし右シフトキーを押したら
        if (Input.GetKey(KeyCode.RightShift))
        {
            // どれくらいのスピードでズームアップするかは下記で決まる。
            //zoom変数に-1.2ｆづつ引く
            zoom -= 1.2f;
            // 下記のコードがなぜ必要なのか考えてみよう。
            //もしzoomが-40f未満だった場合
            if ( zoom < -40f)
            {
                //zoom変数に-40fを代入する
                zoom = -40f;
            }
        }
        else // ここでのelseの内容を考えてみよう。//違う場合
        {
            //zoom変数に1.2ｆづつ加算する
            zoom += 1.2f;
            // 下記のコードがなぜ必要なのか考えてみよう。
            //もしzoom変数が0以上だった場合
            if (zoom > 0)
            {
                //zoom変数に0を代入する
                zoom = 0;
            }
        }
        // zoomの値がどのように変化するか確認してみよう！
        print("zoomの値" + zoom);
    }

}
