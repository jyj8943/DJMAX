using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitLineSpawner : MonoBehaviour
{
    public GameObject BitLine;
    
    private float sapcing_16Bit = 1f;
    private float startPosY = -2f;

    private const int Num16BitLines = 16;

    private void Start()
    {
        EditorManager.Instance.bitLineSpawner = this;
        
        Spawn16BitLines(3);
    }

    private void Spawn16BitLines(int amount)
    {
        for (int i = 0; i < Num16BitLines * amount; i++)
        {
            var pos = new Vector2(0, startPosY + i);
            var line = Instantiate(BitLine, pos, Quaternion.identity);

            if ((i % 2) == 0)
            {
                // 32비트는 파랑색
                line.GetComponent<SpriteRenderer>().color = Color.blue;
            }
            
            if ((i % 4) == 0)
            {
                // 16비트는 초록색
                line.GetComponent<SpriteRenderer>().color = Color.green;
            }

            if ((i % 16) == 0)
            {
                // 1마디는 하늘색
                line.GetComponent<SpriteRenderer>().color = Color.cyan;
            }
            
            line.transform.SetParent(this.transform);
        }
    }
}
