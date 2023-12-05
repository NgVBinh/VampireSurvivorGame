using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private float speed;
    private Rigidbody2D rb;
    private Vector2 nextPos;

    private SpriteRenderer spriteRenderer;
    private Animator animator;
    private bool directMove;
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        rb = GetComponent<Rigidbody2D>();
        directMove = spriteRenderer.flipX;
        animator = GetComponentInChildren<Animator>();
        speed = GetComponent<PlayerManager>().character.speed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    public void Move() {

        nextPos = rb.position;
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0f || vertical != 0f)
        {
            if(horizontal != 0)
            {
                nextPos.x += horizontal * speed * Time.deltaTime;

                if (horizontal < 0f)
                {
                    spriteRenderer.flipX = !directMove;
                }
                else
                {
                    spriteRenderer.flipX = directMove;
                }
            }

            if(vertical != 0)
            {
                nextPos.y += vertical*speed*Time.deltaTime;
            }
            animator.SetBool("Move", true);

            rb.position = nextPos;
        }
        else
        {
            animator.SetBool("Move", false);
        }

    }
}
