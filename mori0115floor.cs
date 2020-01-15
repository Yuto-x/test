using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class floor : MonoBehaviour
{

    Transform objfloor;
    Transform objwall;

    GameObject judg;

    public void OnClick()
    {
        //Canvas取得
        GameObject obj = GameObject.Find("Canvas");
        judg = GameObject.Find("objfloor");
        objfloor = obj.transform.Find("wall");
        objwall = obj.transform.Find("floor");

        objfloor.gameObject.SetActive(false);
        objwall.gameObject.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
