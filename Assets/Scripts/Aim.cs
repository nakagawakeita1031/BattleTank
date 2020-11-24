using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Aim : MonoBehaviour
{
    [SerializeField]
    //Image型aimImage変数
    private Image aimImage;

    // Update is called once per frame
    void Update()
    {
        // レーザー（ray）を飛ばす「起点」と「方向」
        //変数rayにアタッチされたカメラからrayを飛ばす①発生位置と②進む方向(z方向)を代入する
        Ray ray = new Ray(transform.position, transform.forward);
       
        //レーザー光を可視化することができる
        //Drawray関数で①発生位置、②z方向に60距離、③描写する色は緑を出力する
        Debug.DrawRay(transform.position, transform.forward * 60, Color.green, 5);

        // rayのあたり判定の情報を入れる箱を作る。
        //ｒayが衝突したコライダの情報を取得する。
        RaycastHit hit;

        //もしrayがオブジェクトのコライダ(60距離以内)に衝突した場合
        if (Physics.Raycast(ray, out hit, 60))
        {
            //文字列型hitName変数にゲームオブジェクトのタグを代入する
            string hitName = hit.transform.gameObject.tag;

            //もしタグの名前がEnemyなら
            if (hitName == "Enemy")
            {
                // 照準器の色を「赤」に変える（色は自由に変更してください。）
                //aimImage変数の色を赤に変える
                aimImage.color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            }
            //違う場合
            else
            {
                // 照準器の色を「水色」（色は自由に変更してください。）
                //aimImage変数の色を水色に変える
                aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
            }
        }
        //オブジェクトのコライダに衝突してない場合は
        else
        {
            // 照準器の色を「水色」（色は自由に変更してください。
            //aimImage変数の色を水色に変える
            aimImage.color = new Color(0.0f, 1.0f, 1.0f, 1.0f);
        }
    }
}
