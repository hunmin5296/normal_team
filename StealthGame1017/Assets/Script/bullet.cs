using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;

    public int damage = 1; // �Ѿ��� ������

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �浹�� ��ü�� "��" �±׸� ������ �ִ��� Ȯ��
        if (other.CompareTag("Enemy"))
        {
            // �� ������Ʈ�� TakeDamage �Լ� ȣ��
            other.GetComponent<Enemy>().TakeDamage(damage);

            // �Ѿ� ������Ʈ�� ����
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
