using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HiddenTest : MonoBehaviour
{
    bool hantei = false;

    //List<List> allList = new List<List>();
    //List list1 = new List();
    //List list2 = new List();

    GameObject HidButton; // ボタンの変数
    // Start is called before the first frame update
    void Start()
    {
        //allList.Add(list1);
        //allList.Add(list2);
        //GameObject HidCube = GameObject.Find("HiddenTestCube");
    }

    // Update is called once per frame
    void Update()
    {
        // ボタンを読み込み
        HidButton = GameObject.Find("HiddenButton");
        // ボタンが表示されていたら
        if (HidButton != null)
        {
            
        }
        // ボタンが非表示になったら
        else
        {
            // 判定がfalseだったら入る
            if (hantei == false)
            {
                hantei = true; // 判定をtrueにして1回しか入らないようにしている

                GameObject[] HidTag = GameObject.FindGameObjectsWithTag("Hidden");
                Debug.Log("配列0番目の値→"+HidTag[0]);
                Debug.Log("配列1番目の値→"+HidTag[1]);
                Debug.Log("配列2番目の値→"+HidTag[2]);
                Debug.Log("配列3番目の値→"+HidTag[3]);
                HidTag[0].SetActive(false);
            }
        }
    }
}
