using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    //int型score変数に0を代入
    private int score = 0;
    //Text型のscoreLabel変数
    private Text scoreLabel;

    // Start is called before the first frame update
    void Start()
    {
        //scoreLabel変数にコンポーネントのTextを取得する
        scoreLabel = GetComponent<Text>();
        //scoreLabelのtextにSCORE:scoreを表示する
        scoreLabel.text = "SCORE:" + score;
    }

    //スコアを増加させるメソッド
    //（ポイント）外部からアクセスするためpublicで定義すること

    public void AddScore(int amount)//AddScoreメソッド呼び出し
    {
        //scoreにamountを加え続ける
        score += amount;
        //scoreLabelのtext にSCORE:scoreを代入する
        scoreLabel.text = "SCORE:" + score;
    }
}
