using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    Transform playerTransform;
    // 플레이어와의 거리 추정
    Vector3 Offset;
    // Start is called before the first frame update
    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // 맨 마지막에 업데이트 됨
    private void LateUpdate()
    {
        //Update에서 연산을 하고 따라 붙음
        transform.position = playerTransform.position + Offset;
    }
}
