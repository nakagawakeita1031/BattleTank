using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    //moveSpeed変数にfloat型の情報を代入
    public float moveSpeed;
    //turnSpeed変数にfloat型の情報を代入
    public float turnSpeed;
    //rb変数にぶ物理特性を追加する(このクラスでのみ参照可)
    private Rigidbody rb;
    //movementInputValue変数にfloat型の情報を代入(このクラスでのみ参照可)
    private float movementInputValue;
    //turnInputValue変数にfloat型の情報を代入(このクラスでのみ参照可)
    private float turnInputValue;

    // Start is called before the first frame update
    void Start()
    {
        //rb変数に物理特性を追加する
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //メソッドTankMove呼び出し
        TankMove();
        //メソッドTankTurn呼び出し
        TankTurn();
    }

    // 前進・後退のメソッド
    void TankMove()
    {
        //GetAxis←垂直方向の移動量を示す
        //Horizontal←水平方向の移動量を示す
        //この２つは、入力されるさまざまな入力情報をまとめて、必要な種類の値を返すようにしてくれるメソッド
        //movementInputValue変数に垂直方向の移動量を入力できるメソッドを代入する
        movementInputValue = Input.GetAxis("Vertical");

        //Vector3情報を持つmovement変数にオブジェクトを基準としたZ方向 * moveSpeed変数 * そのフレームで進んだ距離を求めるプロパティを代入する
        Vector3 movement = transform.forward * movementInputValue * moveSpeed * Time.deltaTime;
        //rb(物理特性を持った)変数は----------------------編集中↓
        rb.MovePosition(rb.position + movement);
    }

    // 旋回のメソッド
    void TankTurn()
    {
        turnInputValue = Input.GetAxis("Horizontal");
        float turn = turnInputValue * turnSpeed * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0, turn, 0);
        rb.MoveRotation(rb.rotation * turnRotation);//----------------------編集中↑
    }
}