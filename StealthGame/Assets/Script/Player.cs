using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // 플레이어 이동 속도
    public float jumpForce = 10f; // 점프 힘

    private Rigidbody2D rb;
    private bool isGrounded;

    public int maxHealth = 10;
    public int health;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
    }

    void Update()
    {
        // 플레이어의 이동 입력을 받습니다.
        float horizontalInput = Input.GetAxis("Horizontal");

        // 입력을 기반으로 플레이어의 속도를 설정합니다.
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Rigidbody2D 컴포넌트를 사용하여 플레이어를 움직입니다.
        rb.velocity = movement;

        // 점프 입력을 받습니다.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // 플레이어가 땅에 있고, 점프 버튼을 누르면 점프합니다.
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // 플레이어 위치를 따라가는 카메라
        CameraFollowPlayer();

   
    }

    // 플레이어가 땅에 닿았을 때 호출되는 함수
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    // 플레이어가 땅에서 떨어졌을 때 호출되는 함수
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    // 플레이어 위치를 따라가는 카메라
    private void CameraFollowPlayer()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }


    public void TakeDamage(int damage)
    {
        health -= damage;
        if (health < 0)
        {
            Destroy(gameObject);
        }
    }



}
