using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tajigenn : MonoBehaviour
{
    public GameObject cube;

    //3次元用の範囲
    public int m_x = 10;
    public int m_y = 10;
    public int m_z = 10;

    // Start is called before the first frame update
    void Start()
    {
        //3次元の配列を置く
        int[ , , ] field = new int[m_x, m_y, m_z];

        //交互に1と0を代入
        for(int i = 0; i < field.GetLength(0); i++)
        {
            for (int j = 0; j < field.GetLength(1) ; j++)
            {
                for(int k = 0;k < field.GetLength(2); k++)
                {
                if(i % 2 == 0 && j % 2 == 0 && k % 2 == 0)
                    {
                        field[i, j, k] = 1;
                    }
                    else
                    {
                        field[i, j, k] = 0;
                    }
                }
                
            }
        }
        
        //各インデックスに代入された値をもとに生成するorしない
        for(int i = 0;i < field.GetLength(0); i++)
        {
            for(int j = 0; j < field.GetLength(1); j++)
            {
                for (int k = 0; k < field.GetLength(2); k++)
                {
                    //インデックスの値が1の時、cubeを生成
                    if (field[i, j, k] == 1)
                    {
                        GameObject wall = Instantiate(cube);
                        wall.transform.position = new Vector3(i, j, k);
                    }
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
