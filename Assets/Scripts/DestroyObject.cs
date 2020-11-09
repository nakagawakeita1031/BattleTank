﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 砲弾でオブジェクトを破壊
/// </summary>
public class DestroyObject : MonoBehaviour
{
    // エフェクトプレハブのデータを入れるための箱を作る。
    [SerializeField]
    private GameObject effectPrefab;

    [SerializeField]
    private GameObject effectPrefab2; // 2種類目のエフェクトを入れるための箱
    public int objectHP;

    // このメソッドはぶつかった瞬間に呼び出される
    //Collider型のオブジェクトに衝突が検出されると呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手のTagにShellという名前が書いてあったならば（条件）
        //もし衝突した相手オブジェクトのTagにShellという名前がある場合
        if (other.CompareTag("Shell"))
        {
            // オブジェクトのHPを１ずつ減少させる。
            objectHP -= 1;

            // もしもHPが0よりも大きい場合には（条件）
            if (objectHP > 0)
            {

                // このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
                //このゲームオブジェクト(この場合Block)を破棄する
                Destroy(other.gameObject);

                // エフェクトを実体化（インスタンス化）する
                GameObject effect = Instantiate(effectPrefab, other.transform.position, Quaternion.identity);
                // エフェクトを２秒後に画面から消す
                Destroy(effect, 2.0f);
            }
            else
            {
                Destroy(other.gameObject);

                // もう１種類のエフェクを発生させる。
                GameObject effect2 = Instantiate(effectPrefab2, other.transform.position, Quaternion.identity);
                Destroy(effect2, 2.0f);

                // ぶつかってきたオブジェクトを破壊する
                // otherがどこと繋がっているか考えてみよう！
                //ゲームオブジェクト(この場合ShotShell)を破棄する
                Destroy(this.gameObject);
            }
        }
    }
}
