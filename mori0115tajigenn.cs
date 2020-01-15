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

    string startObjectName = "";
    string endObjectName = "";


    //3次元の配列を置く
    int[,,] field = new int[10, 10, 10];
    int count = 0;

    //オブジェクト判定用の変数
    string Wall = "masu";

    //クリック用の変数
    Vector3 tmp = new Vector3(0, 0, 0);
    Vector3 tmp1 = new Vector3(0, 0, 0);
    Vector3 tmp2 = new Vector3(0, 0, 0);
    Vector3 tmp3 = new Vector3(0, 0, 0);

    int cubecount = 0;
    int roomcount = 1;

    bool a = true;

    // オブジェクト削除用変数
    Vector3 TagPos = new Vector3(0, 0, 0);
    string gameObjName = "";


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

        
        if (objfloor != null)
        {
            

            // ボタンを押した処理
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //スタートの座標を取得
                if (Physics.Raycast(ray, out hit))
                {
                    startObjectName = hit.collider.gameObject.name;
                    
                    tmp = GameObject.Find(startObjectName).transform.position;
                    

                    tmp1 = tmp;
                }

            }

            //ボタンを離した処理
            if (Input.GetMouseButtonUp(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //エンドの座標を取得
                if (Physics.Raycast(ray, out hit))
                {
                    endObjectName = hit.collider.gameObject.name;
                    
                    tmp = GameObject.Find(endObjectName).transform.position;
                    

                    tmp2 = tmp;

                    //重なったら上に出力させないようにする
                    if (startObjectName.Contains("masu") || endObjectName.Contains("masu"))
                    {

                    }
                    else
                    {
                        if (tmp1.x >= tmp2.x || tmp1.y >= tmp2.y)
                        {

                            tmp3.x = tmp1.x - tmp2.x;
                            tmp3.y = tmp1.y - tmp2.y;

                            for (int s = 0; tmp3.y >= s; s++)
                            {
                                tmp.y = tmp1.y - s;


                                for (int t = 0; tmp3.x >= t; t++)
                                {

                                    tmp.x = tmp1.x - t;

                                    tmp.z = tmp1.z;

                                    // 選択した座標を配列の要素番号に代入からのその上に床オブジェクトを配置
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
                                        wall.tag = "room" + roomcount;
                                    }
                                }

                            }

                            for (int s = 0; tmp3.y >= s; s++)
                            {
                                tmp.y = tmp1.y - s;


                                for (int t = 0; tmp3.x >= t; t++)
                                {

                                    tmp.x = tmp1.x - t;

                                    tmp.z = tmp1.z;

                                    if (field[(int)tmp.x + 1, (int)tmp.y, (int)tmp.z + 1] == 0 || field[(int)tmp.x - 1, (int)tmp.y, (int)tmp.z + 1] == 0 || field[(int)tmp.x, (int)tmp.y + 1, (int)tmp.z + 1] == 0 || field[(int)tmp.x, (int)tmp.y - 1, (int)tmp.z + 1] == 0)
                                    {
                                        // 選択した座標を配列の要素番号に代入からのその上に壁オブジェクトを配置
                                        field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 2] = 1;
                                        field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 3] = 1;
                                        field[(int)tmp.x, (int)tmp.y, (int)tmp.z + 4] = 1;

                                        //インデックスの値が1の時、cubeを生成
                                        for (int u = 2; u <= 4; u++)
                                        {
                                            if (field[(int)tmp.x, (int)tmp.y, (int)tmp.z + u] == 1)
                                            {
                                                //Assetsからmasuを取得
                                                GameObject wall = Instantiate(masu);

                                                //オブジェクト生成時に"masu番号"に名前変更
                                                wall.name = "masu" + count;
                                                wall.transform.position = new Vector3(tmp.x, tmp.y, tmp.z + u);
                                                count++;
                                                wall.tag = "room" + roomcount;
                                            }
                                        }
                                    }

                                }
                            }

                    

                        }
                    }
                }

                roomcount++;  
            }


                
            
        }
        else
        {
            // ボタンを押した処理
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                //座標を取得
                if (Physics.Raycast(ray, out hit))
                {
                    startObjectName = hit.collider.gameObject.name;

                    tmp = GameObject.Find(startObjectName).transform.position;

                }

                GameObject tagname = GameObject.Find(startObjectName);

                GameObject[] deletetag = GameObject.FindGameObjectsWithTag(tagname.tag);

                foreach (GameObject gameObj in deletetag)
                {
                    gameObjName = gameObj.name;
                    TagPos = GameObject.Find(gameObjName).transform.position;
                    Debug.Log("消したオブジェクト→"+gameObjName + "座標→"+TagPos);

                    field[(int)TagPos.x, (int)TagPos.y, (int)TagPos.z] = 0;


                    Destroy(gameObj);
                }

            }

        }



    }
}
