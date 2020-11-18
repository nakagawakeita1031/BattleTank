using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopAttackItem : MonoBehaviour
{
    private GameObject[] targets;
    [SerializeField]
    private AudioClip getSound;
    [SerializeField]
    private GameObject effectPrefab;

    void Update()
    {
        // 「EnemyShotShell」オブジェクトに「EnemyShotShell」タグを設定してください（ポイント）
        targets = GameObject.FindGameObjectsWithTag("EnemyShotShell");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(targets.Length);
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(targets.Length);
            for (int i = 0; i < targets.Length; i++)
            {
                // 攻撃停止時間を３秒加算する（何秒間加算するかは自由）
                targets[i].GetComponent<EnemyShotShell>().AddStopTimer(3.0f);
            }

            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(getSound, transform.position);
            GameObject effect = Instantiate(effectPrefab, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
        }
    }
}
