using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public int damage = 1; // 총알의 데미지

    private void OnTriggerEnter2D(Collider2D other)
    {
        // 충돌한 객체가 "적" 태그를 가지고 있는지 확인
        if (other.CompareTag("Enemy"))
        {
            // 적 오브젝트의 TakeDamage 함수 호출
            other.GetComponent<Enemy>().TakeDamage(damage);

            // 총알 오브젝트를 제거
            Destroy(gameObject);
        }
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
