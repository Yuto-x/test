using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageBase : MonoBehaviour
{

    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RaycastHit hit; // 光線に当たったオブジェクトを受け取るクラス
        Ray ray; // 光線クラス

        // スクリーン座標に対してマウスの位置の光線を取得
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        
        // スクリーン座標の先にオブジェクトが存在していたら hit に入る
        if(Physics.Raycast(ray,out hit))
        {
            // 当たったオブジェクトの TileBase クラスを取得
            string objectName = hit.collider.gameObject.name; //オブジェクト名を取得して変数に入れる
            Debug.Log(objectName); //オブジェクト名をコンソールに表示
            TileBase tile_base = hit.collider.GetComponent<TileBase>();
            tile_base.bColorState = true;
        }
    }
}
