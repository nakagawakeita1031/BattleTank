﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void OnTriggerEnter(Collider other)//他のオブジェクトが接触した瞬間
    {
        // もしもぶつかってきた相手のTagが”EnemyShell”であったならば（条件）
        if (other.gameObject.tag == "EnemyShell")
        {
            // HPを１ずつ減少させる。
            tankHP -= 1;

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
                Destroy(gameObject);
            }
        }
    }
}
