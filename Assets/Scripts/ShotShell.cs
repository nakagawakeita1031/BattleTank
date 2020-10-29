using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotShell : MonoBehaviour
{
    //shotSpeed変数にfloat型の情報を代入
    public float shotSpeed;

    // privateの状態でもInspector上から設定できるようにするテクニック。
    //SerializeField←データ構造やオブジェクトの状態を、保存・再構築できるようなフォーマットに変換する
    //shellPrefab変数にGameObject型の情報を代入
    [SerializeField]
    private GameObject shellPrefab;

    //shotSound変数に音を鳴らすファイルをアサインできる情報を代入する
    [SerializeField]
    private AudioClip shotSound;


    // Update is called once per frame
    void Update()
    {
        // もしもSpaceキーを押したならば（条件）
        // 「Space」の部分を変更することで他のキーにすることができる（ポイント）
        //もしSpaceキーを入力した場合
        if (Input.GetKeyDown(KeyCode.Space))
        {
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

}
