using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed,jumpH;
    private float velX, velY;
    private Rigidbody2D rb;
    
    public Transform groundCheck;
    public bool isGrounded;
    public float groudCheckRadius;
    public LayerMask whatIsGround;

    [SerializeField]
    private ParticleSystem particle;
    private Animator anim;

    public AudioClip salto, ataque;

    private AudioSource music;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        music = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        MovePlayer();
        Jump();
    }

    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groudCheckRadius, whatIsGround);
        FlipPlayer();
        if (isGrounded)
        {
            anim.SetBool("jump",false);
        }
        else
        {
            anim.SetBool("jump",true);
        }
        Attack();
      
    }

    private void MovePlayer()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX * speed, velY);
        particle.Play();
        if (rb.velocity.x != 0)
        {
            anim.SetBool("run",true);
        }
        else
        {
            anim.SetBool("run",false);
        }
    }

    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
        
            anim.SetBool("attack",true);
        }
        else if(Input.GetKeyUp(KeyCode.E))
        {
            anim.SetBool("attack",false);
        }
    }
    private void FlipPlayer()
    {
        if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if(rb.velocity.x<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void Jump()
    {
        if (Input.GetButton("Jump") && isGrounded)
        {
            music.PlayOneShot(salto);
            rb.velocity = new Vector2(rb.velocity.x, jumpH);
            particle.Play();
        }
      
    }
}
