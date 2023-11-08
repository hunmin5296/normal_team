using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5; // ���� �ʱ� ü��

    // �Ѿ��� ������ ����� �� ȣ��Ǵ� �Լ�
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // ���� ���� �� ȣ��Ǵ� �Լ�
    void Die()
    {
        // �� ������Ʈ�� ���� �Ǵ� �ٸ� ���� ��
        Destroy(gameObject);
    }
}
