using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementVagabond : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    [SerializeField] private float speed,jumpH;
    private float velX, velY;

    private bool isGround;
    [SerializeField] private Transform ground;
    [SerializeField] private float radiousGround;
    [SerializeField] private LayerMask whatisGround;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(ground.position, radiousGround, whatisGround);
        if (!isGround)
        {
            anim.SetBool("jump",true);
        }
        else
        {
            anim.SetBool("jump",false);
        }
        FlipPlayer();
        AttackPlayer();
    }

    private void FixedUpdate()
    {
        MovePlayer();
        JumpPlayer();
    }

    private void MovePlayer()
    {
        velX = speed * Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX, velY);
        if (rb.velocity.x != 0)
        {
            anim.SetBool("run",true);
        }
        else
        {
            anim.SetBool("run",false);
        }
    }

    private void JumpPlayer()
    {
        if (Input.GetButton("Jump")&& isGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpH);
        }
    }
    private void FlipPlayer()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }else if (rb.velocity.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void AttackPlayer()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            anim.SetBool("attack",true);
        }else if (Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("attack",false);
        }
    }
}
