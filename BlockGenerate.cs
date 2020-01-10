using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerate : MonoBehaviour
{
    // 変数定義
    private RaycastHit hit;
    int CubeCount = 0;
    float[] Coordinatearray;
    Vector3 ObjPlace = new Vector3(0, 0, 0);
    Vector3 OddClick = new Vector3(0, 0, 0);
    Vector3 EvenClick = new Vector3(0, 0, 0);
    int Judg = 0;
    string ObjName = "";
    void Update()
    {
        // クリック時に実行
        if (Input.GetMouseButtonDown(0))
        {
            CubeCount += 1;
            // クリックが奇数か偶数かの判定するための変数
            Judg = CubeCount % 2;

            // マウスポインタの座標を取得
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // マウスポインタの座標にオブジェクトが存在したらhitに入る
            if (Physics.Raycast(ray, out hit))
            {

                // オブジェクト名の取得
                ObjName = hit.collider.gameObject.name;

                // 取得したオブジェクト名をもとにオブジェクトの座標を取得
                ObjPlace = GameObject.Find(ObjName).transform.position;

                    // クリックが奇数の時
                    if (Judg == 1)
                    {
                        OddClick = ObjPlace;
                    }
                    //
                    else if (Judg == 0)
                    {
                        EvenClick = ObjPlace;
                    }

                //取得したオブジェクト名の中に変数Wallで設定した値が入っているか
                if (ObjName.Contains("Wall"))
                {

                }
                else
                {

                }
            }
        
        }
    }
}
