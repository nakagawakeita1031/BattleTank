using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShotShell : MonoBehaviour
{
    //shotSpeed変数にfloat型の情報を代入
    public float shotSpeed;

    // privateの状態でもInspector上から設定できるようにするテクニック。
    //SerializeField←データ構造やオブジェクトの状態を、保存・再構築できるようなフォーマットに変換する
    //shellPrefab変数にGameObject型の情報を代入
    [SerializeField]
    private GameObject shellPrefab = null;

    //shotSound変数に音を鳴らすファイルをアサインできる情報を代入する
    [SerializeField]
    private AudioClip shotSound = null;

    private float timeBettweenShot = 0.75f;

    private float timer;

    public int shotCount;

    [SerializeField]
    private Text shellLabel;

    // 残弾数の最大値を設定する（最大値は自由）
    public int shotMaxCount = 20; 

    // Startの「S」は大文字なので注意！
    void Start()
    {
        shotCount = shotMaxCount;

        shellLabel.text = "砲弾：" + shotCount;
    }

    // Update is called once per frame
    void Update()
    {
        // タイマーの時間を動かす
        timer += Time.deltaTime;

        // もしもSpaceキーを押したならば（条件）
        // 「Space」の部分を変更することで他のキーにすることができる（ポイント）
        //もしSpaceキーを入力した場合
        if (Input.GetKeyDown(KeyCode.Space) && timer > timeBettweenShot && shotCount > 0)
        {
            //ショットカウントを-1する
            shotCount -= 1;

            shellLabel.text = "砲弾：" + shotCount;


            // タイマーの時間を０に戻す。
            timer = 0.0f;

            // 砲弾のプレハブを実体化（インスタンス化）する。
            //GameObject型のshell変数に引数で生成したクローンを戻り値Shellに代入する
            GameObject shell = Instantiate(shellPrefab, transform.position, Quaternion.identity);

            // 砲弾に付いているRigidbodyコンポーネントにアクセスする。
            //物理特性を持つShellRb変数に生成したshellオブジェクトの物理特性を代入する
            Rigidbody shellRb = shell.GetComponent<Rigidbody>();

            // forward（青軸＝Z軸）の方向に力を加える。
            //shellRb変数の物理特性(Z軸 * shotSpeedに入る数値)を加える
            shellRb.AddForce(transform.forward * shotSpeed);

            // 発射した砲弾を３秒後に破壊する。
            // （重要な考え方）不要になった砲弾はメモリー上から削除すること。
            //生成したshellオブジェクトを３秒経過で破棄する
            Destroy(shell, 3.0f);

            // 砲弾の発射音を出す。
            //AudioSouceコンポーネントのPlayClipAtPointメソッドの
            //shotSound変数にアサインした音源と指定した場所にオブジェクトを作成し音を再生する
            AudioSource.PlayClipAtPoint(shotSound, transform.position);
        }
    }

    // 残弾数を増加させるメソッド（関数・命令ブロック）
    // 外部からこのメソッドを呼び出せるように「public」をつける（重要ポイント）
    // この「AddShellメソッド」を「ShellItem」スクリプトから呼び出す。
    public void AddShell(int amount)
    {
        // shotCountをamount分だけ回復させる
        shotCount += amount;

        // ただし、残弾数が最大値を超えないようする。(最大値は自由に設定)
        if (shotCount > shotMaxCount)
        {
            shotCount = shotMaxCount;
        }

        // 回復をUIに反映させる。
        shellLabel.text = "砲弾：" + shotCount;
    }
}
