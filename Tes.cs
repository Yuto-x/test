using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tes : MonoBehaviour
{
    GameObject[] SecondRoomObjList; // 2階の部屋を入れる配列
    GameObject[] SecondRoomTagList; // クリックした部屋のタグを入れる配列
    bool Han = true;
    private RaycastHit hit;
    string ObjectName;
    List<GameObject> myList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Han == true)
        {
            Han = false;
            SecondRoomObjList = GameObject.FindGameObjectsWithTag("Hidden");
            myList.Add(SecondRoomObjList[0]);
            

            Debug.Log("0番目" + myList[0]);
            Debug.Log("0番目" + SecondRoomObjList[1]);
            
            

        }
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                ObjectName = hit.collider.gameObject.name;
                GameObject ObjTag = GameObject.Find(ObjectName);
                SecondRoomTagList = GameObject.FindGameObjectsWithTag(ObjTag.tag);

                foreach(GameObject hairetu in SecondRoomTagList)
                {
                    

                    //Debug.Log("配列"+hairetu);
                    int su = Array.IndexOf(SecondRoomObjList, hairetu);
                    Debug.Log("数"+su);
                }
                
            }
        }
    }
}
