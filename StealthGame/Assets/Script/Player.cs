using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5f; // �÷��̾� �̵� �ӵ�
    public float jumpForce = 10f; // ���� ��

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
        // �÷��̾��� �̵� �Է��� �޽��ϴ�.
        float horizontalInput = Input.GetAxis("Horizontal");

        // �Է��� ������� �÷��̾��� �ӵ��� �����մϴ�.
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);

        // Rigidbody2D ������Ʈ�� ����Ͽ� �÷��̾ �����Դϴ�.
        rb.velocity = movement;

        // ���� �Է��� �޽��ϴ�.
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // �÷��̾ ���� �ְ�, ���� ��ư�� ������ �����մϴ�.
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // �÷��̾� ��ġ�� ���󰡴� ī�޶�
        CameraFollowPlayer();

   
    }

    // �÷��̾ ���� ����� �� ȣ��Ǵ� �Լ�
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    // �÷��̾ ������ �������� �� ȣ��Ǵ� �Լ�
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    // �÷��̾� ��ġ�� ���󰡴� ī�޶�
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
