using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{

    // �Ѿ��� ������ �� �� �� �ڿ� ��������� �����ϴ� ����
    public float destroyTime = 10f;

    void Start()
    {
        // ���� �ð��� ���� �Ŀ� Destroy �Լ��� ȣ���Ͽ� �Ѿ��� �ı��մϴ�.
        Destroy(gameObject, destroyTime);
    }
}
