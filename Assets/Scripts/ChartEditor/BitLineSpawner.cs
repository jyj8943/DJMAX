using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BitLineSpawner : MonoBehaviour
{
    [Header("프리팹 관련")]
    public GameObject BitLine;
    public GameObject BitCount;
    
    [Header("각종 수치들 관련")]
    private float sapcing_16Bit = 1f;
    private float startPosY = -2f;
    public int startBitCount = 3;
    public int extraBitCount = 0;

    private const int Num16BitLines = 16;

    private void Start()
    {
        EditorManager.Instance.bitLineSpawner = this;
        
        Spawn16BitLines(3);
    }

    private void Spawn16BitLines(int amount)
    {
        for (int i = 0; i <= Num16BitLines * amount; i++)
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

                var lineCount = Instantiate(BitCount, pos + new Vector2(-3, 0), Quaternion.identity);
                lineCount.transform.SetParent(this.transform);
                lineCount.GetComponent<TextMeshPro>().text = (i / 16).ToString();
            }
            
            line.transform.SetParent(this.transform);
        }
    }
}
