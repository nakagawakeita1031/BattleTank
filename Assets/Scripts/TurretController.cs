using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// タレット射角
/// </summary>
public class TurretController : MonoBehaviour
{
    //Vector3クラスのangle変数
    private Vector3 angle;
    //audioS変数
    private AudioSource audioS;

    // Start is called before the first frame update
    void Start()
    {
        // Turretの最初の角度を取得する。
        //angle変数にtransformのeulerAngles変数を代入
        angle = transform.eulerAngles;
        //audioS変数にAudioSourceを取得し代入
        audioS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // 割り当てるボタン（キー）は自由に変更可能
        //もしPキーを押した場合
        if (Input.GetKey(KeyCode.P))
        {
            //audioSのチェックを入れる
            audioS.enabled = true;

            //角度xを-0.5ｆづつ回転させる
            angle.x -= 0.5f;

            // （ポイント）親の「旋回角度」に合わせるのが「transform.root.eulerAngles.y」の部分
            //親の角度に子の回転を代入する
            transform.eulerAngles = new Vector3(angle.x, transform.root.eulerAngles.y, 0);

            // 移動できる角度に制限を加える
            //もしxの角度が30未満なら
            if (angle.x < 30)
            {
                //x角度に30を代入
                angle.x = 30;
            }
        }
        //Lキーを押した場合
        else if (Input.GetKey(KeyCode.L))
        {
            //audioSにチェックを入れる
            audioS.enabled = true;
            //x角度+0.5づつ回転させる
            angle.x += 0.5f;
            //親の角度に子の回転を代入する
            transform.eulerAngles = new Vector3(angle.x, transform.root.eulerAngles.y, 0);
            
            //もしxの角度が90以上なら
            if (angle.x > 90)
            {
                //xの角度に90を代入
                angle.x = 90;
            }
        }
        //違う場合
        else
        {
            //audioSのチェックを外す
            audioS.enabled = false;
        }
    }

}
