using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float detectionRange = 10f;
    public float chaseSpeed = 3f;
    public float rotationSpeed = 5f;
    public Transform[] waypoints; // 적 캐릭터가 이동할 경로 지점들
    private int currentWaypointIndex = 0;
    private Transform player;
    private bool isChasing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // 플레이어를 태그 "Player"로 가진 오브젝트에서 찾아서 player 변수에 할당
    }

    private void Update()
    {
        if (CanSeePlayer())
        {
            isChasing = true;
        }

        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    private bool CanSeePlayer()
    {
        Vector3 directionToPlayer = player.position - transform.position;
        float distanceToPlayer = directionToPlayer.magnitude;

        // 플레이어와의 거리가 시야 범위 이내이고, 플레이어를 바라보는 방향에 장애물이 없으면 true 반환
        if (distanceToPlayer <= detectionRange)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer.normalized, detectionRange);
            if (hit.collider != null && hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }

        return false;
    }

    private void ChasePlayer()
    {
        // 플레이어 방향으로 회전
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // 플레이어를 향해 이동
        transform.Translate(Vector3.right * chaseSpeed * Time.deltaTime);
    }

    private void Patrol()
    {
        // 경로 지점을 따라 이동
        if (waypoints.Length > 0)
        {
            Transform currentWaypoint = waypoints[currentWaypointIndex];
            Vector3 moveDirection = currentWaypoint.position - transform.position;
            float distanceToWaypoint = moveDirection.magnitude;

            if (distanceToWaypoint < 0.1f)
            {
                // 현재 지점에 도달하면 다음 지점으로 이동
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                // 경로 지점을 향해 이동
                transform.Translate(moveDirection.normalized * chaseSpeed * Time.deltaTime);
            }
        }
    }
}







 

