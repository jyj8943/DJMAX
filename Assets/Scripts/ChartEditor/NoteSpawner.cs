using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteSpawner : MonoBehaviour
{
    [Header("프리팹 관련")] 
    public GameObject shortNotePrefab;

    [Header("각종 수치 관련")] 
    private Vector3 mousePos;
    private float checkRadius = 0.5f;
    public LayerMask targetLayer;
    
    private void Update()
    {
        // 마우스 왼쪽 버튼 클릭
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스의 스크린 좌표 (픽셀 단위)
            Vector3 mouseScreenPos = Input.mousePosition;

            // 스크린 좌표 → 월드 좌표 변환
            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

            // 2D 게임이라면 z값은 0으로 맞춰주는 게 일반적
            mouseWorldPos.z = 0;

            Debug.Log("마우스 월드 좌표: " + mouseWorldPos);
            mousePos = mouseWorldPos;
            
            CreateShortNote();
        }
    }

    private void CreateShortNote()
    {
        if (mousePos.x > 2 || mousePos.x < -2)
        {
            Debug.Log("그리드 밖을 클릭하셨습니다.");
            return;
        }
        else
        {
            if (0 < mousePos.x && mousePos.x <= 1)
            {
                mousePos.x = 0.5f;
            }
            else if (1 < mousePos.x && mousePos.x <= 2)
            {
                mousePos.x = 1.5f;
            }
            else if (-1 < mousePos.x && mousePos.x <= 0)
            {
                mousePos.x = -0.5f;
            }
            else if (-2 <= mousePos.x && mousePos.x <= -1)
            {
                mousePos.x = -1.5f;
            }
            
            SearchAroundBitLine();
        }
        
        var curShortNote = Instantiate(shortNotePrefab, mousePos, Quaternion.identity);
        curShortNote.transform.SetParent(this.transform);
    }

    private void SearchAroundBitLine()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(mousePos, checkRadius, targetLayer);

        GameObject nearestBitLine = null;
        if (colliders.Length > 0)
        {
            Debug.Log("근처 오브젝트 발견");
            foreach (var line in colliders)
            {
                if (nearestBitLine == null)
                {
                    nearestBitLine = line.gameObject;
                }
                else
                {
                    var distanceFromNearest = Vector2.Distance(mousePos, nearestBitLine.transform.position);
                    var distanceFromLine = Vector2.Distance(mousePos, line.transform.position);
                    
                    if (distanceFromNearest > distanceFromLine)
                    {
                        nearestBitLine = line.gameObject;
                    }
                }
            }

            if (nearestBitLine == null)
            {
                return;
            }
            
            mousePos.y = nearestBitLine.transform.position.y;
            Debug.Log("비트 라인으로 마우스 클릭 Y좌표 보정: " + mousePos);
        }
    }
}
