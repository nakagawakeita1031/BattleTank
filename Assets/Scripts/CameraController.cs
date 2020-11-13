using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

/// <summary>
/// 複数のカメラを切り替え
/// </summary>
public class CameraController : MonoBehaviour
{
    [SerializeField]
    //Camera型mainCamera変数
    private Camera mainCamera;

    [SerializeField]
    //Camera型FPSCamera変数
    private Camera FPSCamera;

    // 「bool」は「true」か「false」の二択の情報を扱うことができます（ポイント）
    //boll型mainCameraON変数にtrueを代入
    private bool mainCameraON = true;

    [SerializeField]
    //AudioListener型mainListener変数
    private AudioListener mainListener;

    [SerializeField]
    //AudioListener型のFPSListener変数
    private AudioListener FPSListener;


    void Start()
    {
        //mainCameraのenabledはtrue
        mainCamera.enabled = true;
        //FPSCameraのenabledはfalse
        FPSCamera.enabled = false;

        //mainListenerのenabledをtrueにする
        mainListener.enabled = true; // オンにする
        //FPSListenerのenabledをfalsreにする
        FPSListener.enabled = false; // オフにする
    }

    void Update()
    {
        // （重要ポイント）「&&」は論理関係の「かつ」を意味する。
        // 「A && B」は「A かつ B」（条件AとBの両方が揃った時という意味）
        // 「==」は「左右が等しい」という意味
        // もしも「Cボタン」を押した時、「かつ」、「mainCameraON」のステータスが「true」の時（条件）
        if (Input.GetKeyDown(KeyCode.C) && mainCameraON == true)
        {
            //mainCameraのenabledをfalseにする
            mainCamera.enabled = false;
            //FPSCameraのenabledをtrueにする
            FPSCamera.enabled = true;

            //mainCameraONをfalseにする
            mainCameraON = false;

            mainListener.enabled = false; // オフにする
            FPSListener.enabled = true; // オンにする

        } 
        // もしも「Cボタン」を押した時、「かつ」、「mainCameraON」のステータスが「false」の時（条件）
        else if (Input.GetKeyDown(KeyCode.C) && mainCameraON == false)
        {
            //mainCameraのenabledをtrueにする
            mainCamera.enabled = true;
            //FPSCameraのenabledをfalseにする
            FPSCamera.enabled = false;

            //mainCameraONをfalseにする
            mainCameraON = true;

            mainListener.enabled = true; // オンにする
            FPSListener.enabled = false; // オフにする
        }
    }
}
