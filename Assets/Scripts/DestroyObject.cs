using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 砲弾でオブジェクトを破壊
/// </summary>
public class DestroyObject : MonoBehaviour
{
    // このメソッドはぶつかった瞬間に呼び出される
    //Collider型のオブジェクトに衝突が検出されると呼び出される
    private void OnTriggerEnter(Collider other)
    {
        // もしもぶつかった相手のTagにShellという名前が書いてあったならば（条件）
        //もし衝突した相手オブジェクトのTagにShellという名前がある場合
        if (other.CompareTag("Shell"))
        {
            // このスクリプトがついているオブジェクトを破壊する（thisは省略が可能）
            //このゲームオブジェクト(この場合Block)を破棄する
            Destroy(this.gameObject);

            // ぶつかってきたオブジェクトを破壊する
            // otherがどこと繋がっているか考えてみよう！
            //ゲームオブジェクト(この場合ShotShell)を破棄する
            Destroy(other.gameObject);
        }
    }
}
