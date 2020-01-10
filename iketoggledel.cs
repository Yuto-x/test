using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class iketoggledel : MonoBehaviour
{
    //フィールド変数
    public bool btnFlg;
    bool Flg;

    //インスペクタからトグルを設定するようにしました。
    [SerializeField] Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        //トグルのオン/オフ イベントを受け取れます
        toggle.onValueChanged.AddListener(changeToggleEvent);
        

        //isOnで状態を取得できます
        var toggleActive = toggle.isOn;

        Debug.Log("delStr内"+toggleActive);
    }

    public void changeToggleEvent(bool isActive)
    {
        btnFlg = isActive;
        Debug.Log(string.Format("今のトグルの状態 : {0}", btnFlg));
        
    }
    
    public void ToggleDelivery(bool ToggleJudg)
    {
        var toggleActive = toggle.isOn;
        ToggleJudg = toggleActive;
        Debug.Log("deleteTL内" + ToggleJudg);
    }



    // Update is called once per frame
    void Update()
    {
        
        /*
        iketoggle wd = new iketoggle();
        wd.changeToggleEvent(Flg);
        Debug.Log(Flg);
        */
    }
}
