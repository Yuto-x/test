using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerate : MonoBehaviour
{
    // 変数定義
    private RaycastHit hit;
    bool Judg = false; // クリックが奇数か偶数か判定するための変数
    float[] Coordinatearray;
    Vector3 ObjPlace = new Vector3(0, 0, 0);
    Vector3 OddClick = new Vector3(0, 0, 0);
    Vector3 EvenClick = new Vector3(0, 0, 0);
    string ObjName = ""; // クリックしてHitしたオブジェクト名を入れる変数
    int[,,] field = new int[100, 4, 40]; // 3次元配列
    public GameObject GrassCube;
    public GameObject WallCube;
    int count = 0;
    Vector3 ObjCreate = new Vector3(0, 0, 0);

    void Start()
    {
        // 3次元配列に0,1を格納
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                for (int k = 0; k < field.GetLength(2); k++)
                {
                    if (j == 0)
                    {
                        field[i, j, k] = 1;
                    }
                    else
                    {
                        field[i, j, k] = 0;
                    }
                }
            }
        }

        // 3次元配列に格納した値をもとにオブジェクトを生成
        for (int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1); j++)
            {
                for (int k = 0; k < field.GetLength(2); k++)
                {
                    if (field[i, j, k] == 1)
                    {
                        GameObject grass = Instantiate(GrassCube);
                        grass.name = "grass" + count;
                        grass.transform.position = new Vector3(i, j, k);
                        count++;
                    }
                }
            }
        }
        count = 0;
    }

    void Update()
    {
        // クリック時に実行
        if (Input.GetMouseButtonDown(0))
        {
            // マウスポインタの座標を取得
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // マウスポインタの座標にオブジェクトが存在したらhitに入る
            if (Physics.Raycast(ray, out hit))
            {

                // オブジェクト名の取得
                ObjName = hit.collider.gameObject.name;

                // 取得したオブジェクト名をもとにオブジェクトの座標を取得
                ObjPlace = GameObject.Find(ObjName).transform.position;
                Debug.Log("オブジェクト座標→" + ObjPlace);
                Debug.Log("オブジェクト名→" + ObjName);
                Debug.Log("フィールド→" + field[(int)ObjPlace.x, (int)ObjPlace.y, (int)ObjPlace.z]);

                // クリックが奇数の時
                if (Judg == false)
                {
                    OddClick = ObjPlace;
                }
                // クリックが偶数の時
                else if (Judg == true)
                {
                    EvenClick = OddClick;
                }
                
                //取得したオブジェクト名の中に変数Wallで設定した値が入っているか
                if (ObjName.Contains("Wall"))
                {

                }
                else
                {
                    if (OddClick.x == EvenClick.x) // X座標(横軸)が同じ
                    {
                        // 1クリック目のZ座標(縦軸)が上で2クリック目のZ座標(縦軸)が下の場合
                        if (OddClick.z > EvenClick.z)
                        {
                            // 1クリック目と2クリック目のZ座標の差をZloopに格納
                            float ZLoop = OddClick.z - EvenClick.z;
                            // Z座標の差の分ループ
                            for (float i = 0; i <= ZLoop; i++)
                            {
                                // 1クリック目の座標を格納
                                ObjPlace.x = OddClick.x;
                                ObjPlace.y = OddClick.y;
                                ObjPlace.z = OddClick.z;
                            }

                            field[(int)ObjPlace.x, (int)ObjPlace.y + 1, (int)ObjPlace.z] = 1;

                            if (field[(int)ObjPlace.x, (int)ObjPlace.y + 1, (int)ObjPlace.z] == 1)
                            {
                                GameObject wall = Instantiate(WallCube);
                                wall.name = "WallCube" + count;
                                wall.transform.position = new Vector3(ObjPlace.x, ObjPlace.y + 1, ObjPlace.z);
                                count++;
                            }
                        }
                        // 2クリック目の座標が上で1クリック目の座標が下の場合
                        else
                        {

                        }
                    }
                    // X座標とZ座標が重ならなかった場合
                    else
                    {
                        // クリックしたオブジェクトのY座標が0
                        if (ObjPlace.y == 0)
                        {
                            // クリックしたオブジェクトの上のフィールドに2を入れる
                            field[(int)ObjPlace.x, (int)ObjPlace.y + 1, (int)ObjPlace.z] = 2;
                            // クリックしたオブジェクトの上のフィールドの値が2の場合
                            if (field[(int)ObjPlace.x, (int)ObjPlace.y + 1, (int)ObjPlace.z] == 2)
                            {
                                // オブジェクト生成
                                GameObject wall = Instantiate(WallCube);
                                wall.name = "WallCube" + count;
                                wall.transform.position = new Vector3(ObjPlace.x, ObjPlace.y + 1, ObjPlace.z);
                                Judg = true;
                                count++;
                            }
                            if (Judg == true)
                            {
                                if (OddClick.x != EvenClick.x && OddClick.z != EvenClick.z)
                                {
                                    OddClick = EvenClick;
                                    Judg = false;

                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
