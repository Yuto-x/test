using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class LinqTes : MonoBehaviour
{
    
    GameObject[] NullDel;
    // Start is called before the first frame update
    void Start()
    {
        
        NullDel = GameObject.FindGameObjectsWithTag("Hidden");
        foreach(GameObject tes1 in NullDel)
        {
            Debug.Log("削除前=" + tes1);
        }
        NullDel[2] = null;
        foreach(GameObject tes in NullDel.Where(e => e != null))
        {
            Debug.Log("削除後=" + tes);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
