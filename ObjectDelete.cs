using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDelete : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnClick()
    {
        // ObjArrange obj_arrange = new ObjArrange();
        // string objname = obj_arrange.ChoiceName;
        //DeleteTargetObj という名前のオブジェクトを取得
        GameObject obj = GameObject.Find("obj(Clone)");
        // 指定したオブジェクトを削除
        Destroy(obj);
    }
}
