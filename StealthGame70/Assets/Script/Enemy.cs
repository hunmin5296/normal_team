using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // �÷��̾��� Transform�� �����ؾ� �մϴ�.
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2.0f; // �Ѿ� �߻� �ӵ�
    private float nextFireTime;

    void Update()
    {
        if (CanSeePlayer() && Time.time > nextFireTime)
        {
            // �÷��̾ ���̰� �Ѿ� �߻� ��� �ð��� ������ �� �Ѿ� �߻�
            Shoot();
        }
    }

    bool CanSeePlayer()
    {
        // ���� �÷��̾� ���̿� ����ĳ��Ʈ�� ����Ͽ� ���� üũ
        Vector2 direction = player.position - transform.position;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, Vector2.Distance(transform.position, player.position));
        if (hit.collider != null && hit.collider.CompareTag("Player"))
        {
            return true;
        }
        return false;
    }

    void Shoot()
    {
        // �Ѿ��� �߻��ϰ� �߻� ��� �ð��� ����
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        nextFireTime = Time.time + 1 / fireRate;
    }
}
