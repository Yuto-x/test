using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjArrange : MonoBehaviour
{
    private RaycastHit hit;
    public string ChoiceName;
    //表示非表示の変数
    GameObject objdelete;

    GameObject judg; // 判定用
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameObject.Find("Canvas");
        judg = GameObject.Find("objdelete");
        objdelete = GameObject.Find("sakujo");

        string cubename = "obj(Clone)";
        Vector3 tmp = new Vector3(0, 0, 0);
        int cubecount = 0;

        // ボタンが押されたとき
        if (Input.GetMouseButtonUp(0))
        {
            // マウスの位置を取得
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            // マウス座標の先にオブジェクトが存在したらhitに入る
            if (Physics.Raycast(ray, out hit))
            {
                // オブジェクト名の取得
                cubename = hit.collider.gameObject.name;
                //cubeTest = .collider.gameObject.name;

                ChoiceName = cubename;

                Debug.Log(cubename);

                // 取得したオブジェクト名をもとにオブジェクトの座標を取得
                tmp = GameObject.Find(cubename).transform.position;
                tmp.z = tmp.z - 1;

                Debug.Log(tmp);

                cubecount += 1;
            }


        }

        if (objdelete == null)
        {
            if(cubename == "obj(Clone)")
            {
                GameObject obje = GameObject.Find("obj(Clone)");

                Destroy(obje);
            }
        }
        else
        {
            // 取得したオブジェクトがクローンでなければ
            if (cubename != "obj(Clone)")
            {
                // prefab "obj" を取得
                GameObject prefab = (GameObject)Resources.Load("Objects/obj");

                GameObject stageObject = GameObject.FindWithTag("haiti");

                GameObject instant_object = (GameObject)
                    GameObject.Instantiate(prefab, tmp, Quaternion.identity);

                Debug.Log(instant_object);
            }
        }

        
    }
}
