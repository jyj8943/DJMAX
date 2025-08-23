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
        Spawn16BitLines();
    }

    private void Spawn16BitLines()
    {
        for (int i = 0; i < Num16BitLines; i++)
        {
            var pos = new Vector2(0, startPosY + i);
            var line = Instantiate(BitLine, pos, Quaternion.identity);

            if ((i % 4) == 0)
            {
                line.GetComponent<SpriteRenderer>().color = Color.green;
            }
            
            line.transform.SetParent(this.transform);
        }
    }
}
