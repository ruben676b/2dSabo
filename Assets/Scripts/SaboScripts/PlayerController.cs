using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Velocidad")]
    public float speed;
    private float velX, velY;
    private Rigidbody2D rb;
    
   [Header("Salto")]
    private bool isGrounded,saltar;
    [SerializeField] private float radious, jumpH;
   

    [SerializeField]
    private ParticleSystem particle;
    private Animator anim;

    public AudioClip salto, ataque;

    private AudioSource music;
    
    private bool m_FacingRight = true;
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
        if (Physics2D.Raycast(transform.position, Vector3.down, radious))
        {
            isGrounded = true;
        }
        else isGrounded = false;

        if (Input.GetButton("Jump"))
        {
            saltar = true;
        }
        else saltar = false;
       
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
        velX = Input.GetAxisRaw("Horizontal")*speed;
        velY = rb.velocity.y;

        rb.velocity = new Vector2(velX*Time.fixedDeltaTime , velY);
        particle.Play();
        if (rb.velocity.x != 0)
        {
            anim.SetBool("run",true);
        }
        else
        {
            anim.SetBool("run",false);
        }
        if (velX > 0 && !m_FacingRight)
        {
            // ... flip the player.
            FlipPlayer();
        }
        // Otherwise if the input is moving the player left and the player is facing right...
        else if (velX < 0 && m_FacingRight)
        {
            // ... flip the player.
            FlipPlayer();
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
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void Jump()
    {
        if (isGrounded && saltar)
        {
            music.PlayOneShot(salto);
            rb.velocity = new Vector2(rb.velocity.x, jumpH);
            particle.Play();
        }
      
    }
}
