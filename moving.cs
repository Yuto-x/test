using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class moving : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 screenPoint; 
    private Vector3 offset;

    Vector3 MOVEX = new Vector3(0.5f, 0, 0); // x軸方向に１マス移動するときの距離
    Vector3 MOVEY = new Vector3(0, 0.5f, 0); // y軸方向に１マス移動するときの距離

    float step = 100f;     // 移動速度
    Vector3 target;      // 入力受付時、移動後の位置を算出して保存 
    Vector3 prevPos;     // 何らかの理由で移動できなかった場合、元の位置に戻すため移動前の位置を保存

    Animator animator;

    // マウスクリック時の処理
    void OnMouseDown()
    {
        this.screenPoint = Camera.main.WorldToScreenPoint(transform.position); 
        this.offset = transform.position - 
            Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        //Debug.Log("ScreenPoint→"+ this.screenPoint);
        //Debug.Log("offset→" + this.offset);

    }

    // マウスを動かしたときの処理
    void OnMouseDrag()
    {
        Vector3 currentScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenPoint) + this.offset;
        transform.position = currentPosition;
        //Debug.Log("currentScreenPoint→" + currentScreenPoint);
        //Debug.Log("currentPosition→" + currentPosition);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 右に自動で移動
        // オブジェクトの座標に値をプラスしている
        //transform.position += new Vector3(1f * Time.deltaTime, 0f, 0f);

        // ① 移動中かどうかの判定。移動中でなければ入力を受付
        if (transform.position == target)
        {
            SetTargetPosition();
        }
        Move();
    }
    // ② 入力に応じて移動後の位置を算出
    void SetTargetPosition()
    {

        prevPos = target;

        if (Input.GetKey(KeyCode.D))
        {
            target = transform.position + MOVEX;
            SetAnimationParam(1);
            return;
        }
        if (Input.GetKey(KeyCode.A))
        {
            target = transform.position - MOVEX;
            SetAnimationParam(2);
            return;
        }
        if (Input.GetKey(KeyCode.W))
        {
            target = transform.position + MOVEY;
            SetAnimationParam(3);
            return;
        }
        if (Input.GetKey(KeyCode.S))
        {
            target = transform.position - MOVEY;
            SetAnimationParam(0);
            return;
        }
    }
    // WalkParam  0;下移動　1;右移動　2:左移動　3:上移動
    void SetAnimationParam(int param)
    {
        animator.SetInteger("WalkParam", param);
    }

    // ③ 目的地へ移動する
    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, step * Time.deltaTime);
    }
}
