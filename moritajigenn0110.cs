using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tajigenn : MonoBehaviour
{
    public GameObject cube;
    public GameObject masu;

    public GameObject objfloor;
    public GameObject judg;


    private RaycastHit hit;

    
    //3次元の配列を置く
    int[,,] field = new int[10, 10, 10];
    int count = 0;

    //オブジェクト判定用の変数
    string Wall = "masu";

    //クリック用の変数
    Vector3 tmp = new Vector3(0, 0, 0);
    Vector3 tmp1 = new Vector3(0, 0, 0);
    Vector3 tmp2 = new Vector3(0, 0, 0);

    int cubecount = 0;

    bool a = true;

    // Start is called before the first frame update
    void Start()
    {
        

        //1と0を代入
        for(int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1) ; j++)
            {
                for(int k = 0;k < field.GetLength(2); k++)
                {
                if(k == 0)
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

        //各インデックスに代入された値をもとに生成するorしない
        
        for(int i = 0;i < field.GetLength(0); i++)
        {
            for(int j = 0; j < field.GetLength(1); j++)
            {
                for (int k = 0; k < field.GetLength(2); k++)
                {
                    //インデックスの値が1の時、cubeを生成
                    if (field[i, j, k] == 1)
                    {
                        GameObject wall = Instantiate(cube);
                        // wallの名前の変更 countによって一つ一つに番号をふる
                        wall.name = "cube" + count;
                        wall.transform.position = new Vector3(i, j, k);
                        count++;
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        GameObject obj = GameObject.Find("Canvas");
        judg = GameObject.Find("objfloor");
        objfloor = GameObject.Find("wall");

        if (objfloor == null)
        {
            //床の連続配置
            string objectName = "";
            // ボタンを押した処理
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    objectName = hit.collider.gameObject.name;
                    Debug.Log("オブジェクト名→" + objectName);
                    tmp = GameObject.Find(objectName).transform.position;
                    Debug.Log("tmp→→→"+tmp);
                }

                tmp.z += 1;

                while (a == true)
                {
                    Debug.Log(tmp);
                    if (field[(int)tmp.x - 1, (int)tmp.y, (int)tmp.z] != 1)
                    {
                        Debug.Log(field[(int)tmp.x - 1, (int)tmp.y, (int)tmp.z]);
                        Debug.Log(tmp);
                        tmp.x -= 1;
                    }
                    else if(field[(int)tmp.x, (int)tmp.y + 1, (int)tmp.z] != 1)
                    {
                        Debug.Log(tmp);
                        tmp.y += 1;
                    }
                    else
                    {
                        Debug.Log(tmp);
                        a = false;
                    }
                }

                Debug.Log(tmp);

                while (field[(int)tmp.x, (int)tmp.y, (int)tmp.z] != 1)
                {
                    // 選択した座標を配列の要素番号に代入かーらーのーその上にオブジェクトを配置
                    field[(int)tmp.x, (int)tmp.y, (int)tmp.z] = 1;

                    //インデックスの値が1の時、cubeを生成
                    if (field[(int)tmp.x, (int)tmp.y, (int)tmp.z] == 1)
                    {
                        //Assetsからmasuを取得
                        GameObject wall = Instantiate(masu);
                        //オブジェクト生成時に"masu番号"に名前変更
                        wall.name = "masu" + count;
                        wall.transform.position = new Vector3(tmp.x, tmp.y, tmp.z);
                        count++;
                    }

                    if(field[(int)tmp.x, (int)tmp.y + 1, (int)tmp.z] == 1 && field[(int)tmp.x + 1, (int)tmp.y, (int)tmp.z] == 0)
                    {
                        tmp.x += 1;
                    }
                    else if(field[(int)tmp.x + 1, (int)tmp.y, (int)tmp.z] == 1 && field[(int)tmp.x, (int)tmp.y - 1, (int)tmp.z] == 0)
                    {
                        tmp.y -= 1;
                    }
                    else if (field[(int)tmp.x, (int)tmp.y - 1, (int)tmp.z] == 1 && field[(int)tmp.x - 1, (int)tmp.y - 1, (int)tmp.z] == 0)
                    {
                        tmp.x -= 1;
                    }
                    else if(field[(int)tmp.x - 1, (int)tmp.y, (int)tmp.z] == 1 && field[(int)tmp.x, (int)tmp.y + 1, (int)tmp.z] == 0)
                    {
                        tmp.y += 1;
                    }
                    

                }
                    

                
                    
            }

        }
        else
        {
            //第一クリックと２クリックを分ける
            int han = cubecount % 2;

            string objectName = "";
            
            // ボタンを押した処理
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    objectName = hit.collider.gameObject.name;
                    Debug.Log(objectName);
                    tmp = GameObject.Find(objectName).transform.position;
                    Debug.Log(tmp);

                    if (han == 0)//１クリック目
                    {
                        tmp1 = tmp;


                        Debug.Log("1クリック目");


                    }
                    else//２クリック目
                    {
                        tmp2 = tmp;


                        Debug.Log("２クリック目");

                    }
                }
                //取得したオブジェクト名の中に変数Wallで設定した値が入っているか
                if (objectName.Contains(Wall))
                {

                }
                else
                {
                    Vector3 tmp3 = new Vector3(0, 0, 0);
                    if (tmp1.x == tmp2.x) //縦に連続
                    {
                        if (tmp1.y > tmp2.y) //〇
                        {


                            float numberX = tmp1.y - tmp2.y;
                            Debug.Log("高さの差異　：　" + numberX);
                            for (float i = 0; i < numberX; i++) // numberX-6を消すと視点側に1マス増える　
                            {                                           // <= の = を消すと視点の次のマスが1マス消える

                                // tmp3に座標を設定
                                //float b = i;
                                tmp.x = tmp1.x;
                                tmp.y = tmp2.y + i;// -6すると押したマスより奥に移動する +6すると下から2→1が成功する
                                tmp.z = tmp1.z;

                                // 選択した座標を配列の要素番号に代入かーらーのーその上にオブジェクトを配置
                                field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] = 1;

                                //インデックスの値が1の時、cubeを生成
                                if (field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] == 1)
                                {
                                    //Assetsからmasuを取得
                                    GameObject wall = Instantiate(masu);
                                    //オブジェクト生成時に"masu番号"に名前変更
                                    wall.name = "masu" + count;
                                    wall.transform.position = new Vector3(tmp.x, tmp.y, tmp.z + 1);
                                    count++;
                                }
                            }
                        }
                        else //tmp1とtmp2の位置関係が逆な場合
                        {
                            float numberX = tmp2.y - tmp1.y;
                            Debug.Log(numberX);
                            for (float i = 0; i < numberX; i++)
                            {

                                // tmp3に座標を設定
                                // float b = i;
                                tmp.x = tmp1.x;
                                tmp.y = tmp1.y + i;
                                tmp.z = tmp1.z;

                                // 選択した座標を配列の要素番号に代入かーらーのーその上にオブジェクトを配置
                                field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] = 1;

                                //インデックスの値が1の時、cubeを生成
                                if (field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] == 1)
                                {
                                    //Assetsからmasuを取得
                                    GameObject wall = Instantiate(masu);
                                    //オブジェクト生成時に"masu番号"に名前変更
                                    wall.name = "masu" + count;
                                    wall.transform.position = new Vector3(tmp.x, tmp.y, tmp.z + 1);
                                    count++;
                                }
                            }
                        }
                        tmp1 = new Vector3(0, 0, 0);
                        tmp2 = new Vector3(0, 0, 0);

                        Debug.Log("初期化");

                    }

                    else if (tmp1.y == tmp2.y) //横に連続
                    {
                        if (tmp1.x >= tmp2.x) //〇
                        {


                            float numberY = tmp1.x - tmp2.x;
                            Debug.Log(numberY);
                            for (float i = 0; i < numberY; i++)
                            {

                                // tmp3に座標を設定
                                //float b = i;
                                tmp.x = tmp2.x + i;
                                tmp.y = tmp2.y;
                                tmp.z = tmp1.z;

                                // 選択した座標を配列の要素番号に代入かーらーのーその上にオブジェクトを配置
                                field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] = 1;

                                //インデックスの値が1の時、cubeを生成
                                if (field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] == 1)
                                {
                                    //Assetsからmasuを取得
                                    GameObject wall = Instantiate(masu);
                                    //オブジェクト生成時に"masu番号"に名前変更
                                    wall.name = "masu" + count;
                                    wall.transform.position = new Vector3(tmp.x, tmp.y, tmp.z + 1);
                                    count++;
                                }
                            }
                        }
                        else //tmp1とtmp2の位置関係が逆な場合 //OK
                        {
                            float numberY = tmp2.x - tmp1.x;
                            Debug.Log(numberY);
                            for (float i = 0; i < numberY; i++)
                            {

                                // tmp3に座標を設定
                                // float b = i;
                                tmp.x = tmp1.x + i;
                                tmp.y = tmp1.y;
                                tmp.z = tmp1.z;

                                // 選択した座標を配列の要素番号に代入かーらーのーその上にオブジェクトを配置
                                field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] = 1;

                                //インデックスの値が1の時、cubeを生成
                                if (field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] == 1)
                                {
                                    //Assetsからmasuを取得
                                    GameObject wall = Instantiate(masu);
                                    //オブジェクト生成時に"masu番号"に名前変更
                                    wall.name = "masu" + count;
                                    wall.transform.position = new Vector3(tmp.x, tmp.y, tmp.z + 1);
                                    count++;
                                }


                            }
                        }
                        tmp1 = new Vector3(0, 0, 0);
                        tmp2 = new Vector3(0, 0, 0);
                        Debug.Log("初期化");
                    }


                    else
                    {
                        // 選択した座標を配列の要素番号に代入かーらーのーその上にオブジェクトを配置
                        field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] = 1;

                        //インデックスの値が1の時、cubeを生成
                        if (field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 1] == 1)
                        {
                            //Assetsからmasuを取得
                            GameObject wall = Instantiate(masu);
                            //オブジェクト生成時に"masu番号"に名前変更
                            wall.name = "masu" + count;
                            wall.transform.position = new Vector3(tmp.x, tmp.y, tmp.z + 1);
                            count++;
                        }
                        if (han == 1)
                        {
                            if (tmp1.x != tmp2.x && tmp1.y != tmp2.y)
                            {
                                tmp1 = tmp2;
                                cubecount += 1;
                            }
                        }
                    }

                }
                cubecount += 1;
                /*
                // オブジェクト名からオブジェクトを削除
                GameObject obje = GameObject.Find(objectName);

                Destroy(obje);
                */




            }
        }

        
        

    }
}
