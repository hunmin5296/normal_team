using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 5; // 적의 초기 체력

    // 총알이 적에게 닿았을 때 호출되는 함수
    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    // 적이 죽을 때 호출되는 함수
    void Die()
    {
        // 적 오브젝트를 제거 또는 다른 동작 수
        Destroy(gameObject);
    }
}
