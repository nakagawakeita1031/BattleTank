using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 敵の砲弾
/// </summary>
public class EnemyShotShell : MonoBehaviour
{
    public float shotSpeed;
    [SerializeField]
    private GameObject enemyShellPrefab;
    [SerializeField]
    private AudioClip shotSound;
    private int interval;

    // 何秒間停止させるかは自由
    public float stopTimer = 5.0f;

    [SerializeField]
    private Text stopLabel;

    void Update()
    {
        interval += 1;

        stopTimer -= Time.deltaTime;
        // タイマーが0未満になったら、0で止める。
        if (stopTimer < 0)
        {
            stopTimer = 0;
        }

        stopLabel.text = "" + stopTimer.ToString("0");//小数点以下は切り捨て

        if (interval % 60 == 0 && stopTimer <= 0)
        {
            GameObject enemyShell = Instantiate(enemyShellPrefab, transform.position, Quaternion.identity);

            Rigidbody enemyShellRb = enemyShell.GetComponent<Rigidbody>();

            // forwardはZ軸方向（青軸方向）・・・＞この方向に力を加える。
            enemyShellRb.AddForce(transform.forward * shotSpeed);

            AudioSource.PlayClipAtPoint(shotSound, transform.position);

            Destroy(enemyShell, 3.0f);
        }
    }

    // 敵の攻撃をストップさせるメソッド（Timerの時間を増加させることで攻撃の停止時間を伸ばす）
    // （考え方）HPを増加させるアイテム等と同じ
    // このアイテムを複数取得すると、それだけ攻撃停止時間も「加算」される。
    public void AddStopTimer(float amount)
    {
        stopTimer += amount;

        stopLabel.text = "" + stopTimer.ToString("0");
    }

}
