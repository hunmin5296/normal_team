using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    Rigidbody2D rigid;
    public float maxSpeed;
    SpriteRenderer spriteRenderer;
    Animator anim;
    public float JumpPower;

    private bool isJumping = false; // �߰�: ���� ������ ����

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent < SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && !isJumping) // �߰�: ���� ���� �ƴ� ��쿡�� ���� ����
        {
            rigid.AddForce(Vector2.up * JumpPower, ForceMode2D.Impulse);
            isJumping = true; // �߰�: ���� �� ���·� ����
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x * 0.5f, rigid.velocity.y);
        }

        if (Mathf.Abs(rigid.velocity.x) < 0.3)
            anim.SetBool("isWalking", false);
        else
            anim.SetBool("isWalking", true);

        Flip();
    }

    void FixedUpdate()
    {
        float h = Input.GetAxisRaw("Horizontal");

        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        if (rigid.velocity.x > maxSpeed)
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y);
        else if (rigid.velocity.x < maxSpeed * (-1))
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y);

        // �÷��̾� ��ġ�� ���󰡴� ī�޶� ȣ��
        CameraFollowPlayer();
    }

    // �÷��̾� ��ġ�� ���󰡴� ī�޶�
    private void CameraFollowPlayer()
    {
        Camera.main.transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.transform.position.z);
    }

    void Flip()
    {
        if (Input.GetButtonDown("Horizontal"))
        {
            transform.Rotate(0, 180, 0);
        }
    }

    // �߰�: ���� ������ ���� ���� �ʱ�ȭ
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
