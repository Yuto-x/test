using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sampletest : MonoBehaviour
{
    private RaycastHit hit;
    int cubecount = 0;
    float [] Coordinatearray;
    Vector3 tmp1 = new Vector3(0, 0, 0);
    Vector3 tmp2 = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //第一クリックと２クリックを分ける
        int han = cubecount % 2;

        string cubename = "wall(Clone)";
        Vector3 tmp = new Vector3(0,0,0);
        
        
        

        // ボタンを押したときに反応
        if (Input.GetMouseButtonDown(0))
        {
            // マウスの位置を取得
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // 座標の先にオブジェクトが存在したらhitに入る
            if(Physics.Raycast(ray, out hit))
            {
                
                // オブジェクト名の取得
                cubename = hit.collider.gameObject.name;

                Debug.Log(cubename);

                // 取得したオブジェクト名をもとにオブジェクトの座標を取得
                tmp = GameObject.Find(cubename).transform.position;
                //クリックした座標の上にキューブを作るため代入
                //座標のずれを修正
                tmp.x = tmp.x + 3;
                tmp.y = tmp.y - 3;
                tmp.z = tmp.z - 1;


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

            if(cubename != "wall(Clone)")
            {
                
                GameObject prefab = (GameObject)Resources.Load("Objects/wall");
                GameObject stageObject = GameObject.FindWithTag("haiti");

               

                Vector3 tmp3 = new Vector3(0, 0, 0);
                
                if(tmp1.x == tmp2.x)　//縦に連続
                {
                    if (tmp1.y > tmp2.y) //〇
                    {


                        float numberX = tmp1.y - tmp2.y;
                        Debug.Log("高さの差異　：　"+numberX);
                        for (float i = 0; i < numberX ; i += 6) // numberX-6を消すと視点側に1マス増える　
                        {                                           // <= の = を消すと視点の次のマスが1マス消える

                            // tmp3に座標を設定
                            //float b = i;
                            tmp3.x = tmp1.x;
                            tmp3.y = tmp2.y + i;// -6すると押したマスより奥に移動する +6すると下から2→1が成功する
                            tmp3.z = tmp1.z;

                            //キューブを生成
                            GameObject instant_object = (GameObject)GameObject.Instantiate(prefab, tmp3, Quaternion.identity);
                            //取得したオブジェクトの座標を表示
                            tmp3 = GameObject.Find(cubename).transform.position;
                            //Coordinatearray = ;

                            //重なったオブジェクトの座標を表示
                            /*if (temp1 == Coordinatearray)
                            {
                             //   GameObject.Find(cubename).transform.position;
                            }*/



                            Debug.Log("tmp3 ： " + tmp3);
                        }
                    }
                    else //tmp1とtmp2の位置関係が逆な場合
                    {
                        float numberX = tmp2.y - tmp1.y;
                        Debug.Log(numberX);
                        for (float i = 0; i < numberX; i += 6)
                        {

                            // tmp3に座標を設定
                           // float b = i;
                            tmp3.x = tmp1.x;
                            tmp3.y = tmp1.y + i + 6;
                            tmp3.z = tmp1.z;

                            //キューブを生成
                            GameObject instant_object = (GameObject)GameObject.Instantiate(prefab, tmp3, Quaternion.identity);
                           

                            Debug.Log(tmp3);
                        }
                    }
                    tmp1 = new Vector3(0, 0, 0);
                    tmp2 = new Vector3(0, 0, 0);

                    Debug.Log("初期化");

                }

                else if (tmp1.y == tmp2.y)　//縦に連続
                {
                    if (tmp1.x >= tmp2.x) //〇
                    {


                        float numberY = tmp1.x - tmp2.x;
                        Debug.Log(numberY);
                        for (float i = 0; i < numberY; i += 6)
                        {

                            // tmp3に座標を設定
                            //float b = i;
                            tmp3.x = tmp2.x + i;
                            tmp3.y = tmp1.y;
                            tmp3.z = tmp1.z;

                            //キューブを生成
                            GameObject instant_object = (GameObject)GameObject.Instantiate(prefab, tmp3, Quaternion.identity);

                            Debug.Log(tmp3);
                        }
                    }
                    else //tmp1とtmp2の位置関係が逆な場合 //OK
                    {
                        float numberY = tmp2.x - tmp1.x;
                        Debug.Log(numberY);
                        for (float i = 0; i < numberY; i += 6)
                        {

                            // tmp3に座標を設定
                            // float b = i;
                            tmp3.x = tmp1.x + i + 6;
                            tmp3.y = tmp1.y;
                            tmp3.z = tmp1.z;

                            //キューブを生成
                            GameObject instant_object = (GameObject)GameObject.Instantiate(prefab, tmp3, Quaternion.identity);

                            Debug.Log(tmp3);
                        }
                    }
                    tmp1 = new Vector3(0, 0, 0);
                    tmp2 = new Vector3(0, 0, 0);
                    Debug.Log("初期化");
                }


                else
                {
                    //キューブを生成
                    GameObject instant_object = (GameObject)GameObject.Instantiate(prefab, tmp, Quaternion.identity);
                    Debug.Log("作成");
                    if(han == 1)
                    {
                        if(tmp1.x != tmp2.x && tmp1.y != tmp2.y)
                        {
                            tmp1 = tmp2;
                            cubecount += 1;
                        }
                    }
                }

            }
            cubecount += 1;

        }
    }
}
