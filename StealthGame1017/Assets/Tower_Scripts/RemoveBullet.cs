using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{

    // 총알이 생성된 후 몇 초 뒤에 사라질지를 설정하는 변수
    public float destroyTime = 10f;

    void Start()
    {
        // 일정 시간이 지난 후에 Destroy 함수를 호출하여 총알을 파괴합니다.
        Destroy(gameObject, destroyTime);
    }
}
