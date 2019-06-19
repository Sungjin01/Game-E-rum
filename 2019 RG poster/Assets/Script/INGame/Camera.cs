using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 카메라 구성 클래스 (카메라의 움직임)
public class Camera : MonoBehaviour
{
    // 최소 X 좌표와 최대 X 좌표
    public float minPosX, maxPosX;

    private Transform playerPos; // 플레이어 위치

    private void Awake()
    {
        // 플레이어 위치 로드
        playerPos = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        // 카메라의 위치를 지정할 pos 설정 (플레이어의 X 좌표, 고정 Y (1f), 고정 Z (-10))
        Vector3 pos = new Vector3(playerPos.position.x, 5.5f, -10);

        // 만약 X 좌표가 최소값보다 작으면
        if (pos.x < minPosX) //----------------------------------------------------------------------------------------------------//
        {
            pos.x = minPosX; // X 좌표를 최소값으로 고정
        }

        // 만약 X 좌표가 최대값보다 크면
        else if (pos.x > maxPosX) //----------------------------------------------------------------------------------------------------//
        {
            pos.x = maxPosX; // X 좌표를 최대값으로 고정
        }

        transform.position = pos; // 카메라 위치에 직접 적용
    }
}
