using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// オブジェクトをカメラで追従させる
/// </summary>
public class ChaseCamera : MonoBehaviour
{
    [SerializeField]
    //GameObject型のtarget変数
    private GameObject target;
    //Vector3データ型のoffset変数
    private Vector3 offset;

    void Start()
    {
        // カメラとターゲットの最初の位置関係（距離）を取得する。
        offset = transform.position - target.transform.position;
    }

    void Update()
    {
        //ターゲットがnullじゃないか確認
        if (target != null)
        {
            //nullではない場合
            // 最初に取得した位置関係を足すことで常に一定の距離を維持する（ポイント）
            transform.position = target.transform.position + offset;
        }
    }
}
