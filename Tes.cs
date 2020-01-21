using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Tes : MonoBehaviour
{
    private RaycastHit hit;

    List<GameObject> myList = new List<GameObject>();
    GameObject[] SecondRoomObjList; // 2階の部屋を入れる配列

    GameObject[] SecondRoomTagList; // クリックした部屋のタグを入れる配列

    string CreateObjName; // 生成したオブジェクトの名前
    GameObject CreateObjTag; // 生成したオブジェクトのタグ

    string DelObjName = "";
    GameObject DelObjTag;
    GameObject[] DelObjList;

    GameObject[] ArrayList;
        
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                CreateObjName = hit.collider.gameObject.name;
                CreateObjTag = GameObject.Find(CreateObjName);
                // 指定したタグのオブジェクトすべてを2階で生成した部屋(オブジェクト)の配列に　
                SecondRoomObjList = GameObject.FindGameObjectsWithTag(CreateObjTag.tag);
                // 配列に入っているオブジェクトの数だけループ
                foreach (GameObject SecongRoomObj in SecondRoomObjList)
                {
                    myList.Add(SecongRoomObj); // リストに追加
                    Debug.Log("追加したオブジェクト"+SecongRoomObj);
                    Debug.Log("追加時の要素数"+myList.Count());
                }
                
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                DelObjName = hit.collider.gameObject.name;
                DelObjTag = GameObject.Find(DelObjName);
                DelObjList = GameObject.FindGameObjectsWithTag(DelObjTag.tag);
                // リストを配列に変換
                ArrayList = myList.ToArray();
                for(int i = 0; i <= DelObjList.Length-1; i++)
                {
                    Debug.Log("配列の長さ＝"+ DelObjList.Length);
                    int Su = Array.IndexOf(ArrayList, DelObjList[i]);
                    Debug.Log("su=" + Su);
                    ArrayList[Su] = null;
                }
                myList = new List<GameObject>(ArrayList);
                /*
                foreach (GameObject DelLoop in DelObjList)
                {
                    int Su = Array.IndexOf(ArrayList, DelLoop);
                    Debug.Log("su="+Su);
                    ArrayList[Su] = null;
                }
                */
                foreach (GameObject tes in ArrayList.Where(e => e != null))
                {
                    Debug.Log("削除後=" + tes);
                }
            }
        }
    }
}