using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TankHealth : MonoBehaviour
{
    [SerializeField]
    //GameObjectgtのeffectPrefab1変数
    private GameObject effectPrefab1;

    [SerializeField]
    //GameObject型のeffectPrefab2変数
    private GameObject effectPrefab2;
    //int型のtankHP変数
    public int tankHP;

    [SerializeField]
    private Text HPLabel;

    public int tankMaxHP = 5;

    private void Start()
    {
        tankHP = tankMaxHP;

        HPLabel.text = "HP:" + tankHP;
    }


    private void OnTriggerEnter(Collider other)//他のオブジェクトが接触した瞬間
    {
        // もしもぶつかってきた相手のTagが”EnemyShell”であったならば（条件）
        if (other.gameObject.tag == "EnemyShell")
        {
            // HPを１ずつ減少させる。
            tankHP -= 1;

            HPLabel.text = "HP:" + tankHP;

            // ぶつかってきた相手方（敵の砲弾）を破壊する。
            Destroy(other.gameObject);

            if (tankHP > 0)
            {
                GameObject effect1 = Instantiate(effectPrefab1, transform.position, Quaternion.identity);
                Destroy(effect1, 1.0f);
            }
            else
            {
                GameObject effect2 = Instantiate(effectPrefab2, transform.position, Quaternion.identity);
                Destroy(effect2, 1.0f);

                // プレーヤーを破壊する。
                //Destroy(gameObject);

                // プレーヤーを破壊せずに画面から見えなくする（ポイント・テクニック）
                // プレーヤーを破壊すると、その時点でメモリー上から消えるので、以降のコードが実行されなくなる。
                this.gameObject.SetActive(false);

                // 1.5秒後に「GoToGameOver()」メソッドを実行する。
                Invoke("GoToGameOver", 1.5f);

            }
        }
    }

    void GoToGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    // publicをつけること（重要ポイント）
    public void AddHP(int amount)
    {
        tankHP += amount;

        // ここは何をコントロールしている考えてみましょう！
        if (tankHP > tankMaxHP)
        {
            tankHP = tankMaxHP;
        }

        HPLabel.text = "HP:" + tankHP;
    }
}
