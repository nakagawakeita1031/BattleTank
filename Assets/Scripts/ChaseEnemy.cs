using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// 追跡機能
/// </summary>
public class ChaseEnemy : MonoBehaviour
{
    [SerializeField]
    //GameObject型のtarget変数
    private GameObject target;
    //NavMeshAgent型のagent変数
    private NavMeshAgent agent;

    void Start()
    {
        //agent変数にNavMeshAgentを取得(追加)する
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //targetオブジェクトがnullじゃないか確認
        if (target != null)
        {
            //nullじゃない場合
            // ターゲットの位置を目的地に設定する。
            agent.destination = target.transform.position;
        }
    }
}
