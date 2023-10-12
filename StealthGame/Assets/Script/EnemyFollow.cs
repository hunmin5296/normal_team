using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{
    public float detectionRange = 10f;
    public float chaseSpeed = 3f;
    public float rotationSpeed = 5f;
    public Transform[] waypoints; // �� ĳ���Ͱ� �̵��� ��� ������
    private int currentWaypointIndex = 0;
    private Transform player;
    private bool isChasing = false;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        // �÷��̾ �±� "Player"�� ���� ������Ʈ���� ã�Ƽ� player ������ �Ҵ�
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

        // �÷��̾���� �Ÿ��� �þ� ���� �̳��̰�, �÷��̾ �ٶ󺸴� ���⿡ ��ֹ��� ������ true ��ȯ
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
        // �÷��̾� �������� ȸ��
        Vector3 directionToPlayer = player.position - transform.position;
        float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // �÷��̾ ���� �̵�
        transform.Translate(Vector3.right * chaseSpeed * Time.deltaTime);
    }

    private void Patrol()
    {
        // ��� ������ ���� �̵�
        if (waypoints.Length > 0)
        {
            Transform currentWaypoint = waypoints[currentWaypointIndex];
            Vector3 moveDirection = currentWaypoint.position - transform.position;
            float distanceToWaypoint = moveDirection.magnitude;

            if (distanceToWaypoint < 0.1f)
            {
                // ���� ������ �����ϸ� ���� �������� �̵�
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }
            else
            {
                // ��� ������ ���� �̵�
                transform.Translate(moveDirection.normalized * chaseSpeed * Time.deltaTime);
            }
        }
    }
}







 

