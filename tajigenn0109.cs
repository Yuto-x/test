using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tajigenn : MonoBehaviour
{
    public GameObject cube;
    public GameObject masu;
    
    private RaycastHit hit;

    
    //3次元の配列を置く
    int[,,] field = new int[10, 10, 10];
    int count = 0;

    //オブジェクト判定用の変数
    string Wall = "masu";

    // Start is called before the first frame update
    void Start()
    {
        

        //交互に1と0を代入
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
        string objectName = "";
        Vector3 tmp = new Vector3(0, 0, 0);
        // ボタンを押した処理
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if(Physics.Raycast(ray,out hit))
            {
                objectName = hit.collider.gameObject.name;
                Debug.Log(objectName);
                tmp = GameObject.Find(objectName).transform.position;
                Debug.Log(tmp);
            }
            //取得したオブジェクト名の中に変数Wallで設定した値が入っているか
            if (objectName.Contains(Wall))
            {

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
            }
            /*
            // オブジェクト名からオブジェクトを削除
            GameObject obje = GameObject.Find(objectName);

            Destroy(obje);
            */

            
            
            
        }
        

    }
}
