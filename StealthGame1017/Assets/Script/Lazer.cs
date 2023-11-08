using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour
{
    public float walkSpeed = 1.0f;      // Walkspeed
    public float wallLeft = 0.0f;       // Define wallLeft
    public float wallRight = 5.0f;      // Define wallRight
    float walkingDirection = 1.0f;
    Vector2 walkAmount;
    float originalX; // Original float value


    void Start()
    {
        wallLeft = transform.position.x - 2.5f;
        wallRight = transform.position.x + 2.5f;
    }

    // Update is called once per frame
    void Update()
    {
        walkAmount.x = walkingDirection * walkSpeed * Time.deltaTime;
        if (walkingDirection > 0.0f && transform.position.x >= wallRight)
        {
            walkingDirection = -1.0f;
            // 스프라이트를 오른쪽으로 회전
            transform.localScale = new Vector3(0.2f, 4.5f, 1.2f);
        }
        else if (walkingDirection < 0.0f && transform.position.x <= wallLeft)
        {
            walkingDirection = 1.0f;
            // 스프라이트를 왼쪽으로 회전
            transform.localScale = new Vector3(-0.2f, 4.5f, 1.2f);
        }
        transform.Translate(walkAmount);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(collision.gameObject);
            Debug.Log("Destory");

        }
    }
}
