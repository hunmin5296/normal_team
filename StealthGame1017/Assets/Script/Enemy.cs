using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player; // 플레이어의 Transform을 연결해야 합니다.
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 2.0f; // 총알 발사 속도
    private float nextFireTime;

    void Update()
    {
        if (CanSeePlayer() && Time.time > nextFireTime)
        {
            // 플레이어가 보이고 총알 발사 대기 시간이 지났을 때 총알 발사
            Shoot();
        }
    }

    bool CanSeePlayer()
    {
        // 적과 플레이어 사이에 레이캐스트를 사용하여 가시 체크
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
        // 총알을 발사하고 발사 대기 시간을 설정
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        nextFireTime = Time.time + 1 / fireRate;
    }
}
