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
    string CreateTag; // 生成したオブジェクトのタグ(キャスト後)

    string DelObjName = "";
    GameObject DelObjTag;
    string DelTag = "";
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
                CreateTag = Convert.ToString(CreateObjTag);
                // 指定したタグのオブジェクトすべてを2階で生成した部屋(オブジェクト)の配列に　
                SecondRoomObjList = GameObject.FindGameObjectsWithTag(CreateTag);
                // 配列に入っているオブジェクトの数だけループ
                foreach (GameObject SecongRoomObj in SecondRoomObjList)
                {
                    myList.Add(SecongRoomObj); // リストに追加
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
                DelTag = Convert.ToString(DelObjTag);

                DelObjList = GameObject.FindGameObjectsWithTag(DelTag);
                ArrayList = myList.ToArray();
                foreach (GameObject DelLoop in DelObjList)
                {
                    int Su = Array.IndexOf(ArrayList, DelLoop);
                    ArrayList[Su] = null;
                }
                foreach (GameObject tes in ArrayList.Where(e => e != null))
                {
                    Debug.Log("削除後=" + tes);
                }
            }
        }
    }
}
