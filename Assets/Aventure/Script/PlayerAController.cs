using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAController : MonoBehaviour
{
    // creamos un variable de typo rigidbody2d que almacenara el rigidbody del jugador
    private Rigidbody2D rb;
    private float velX, velY;
    public float speed,jumpH;
    //creamos un variable de tipo animator que almacenara la animacion que esta usando el jugador
    private Animator anim;

    public Transform ground;

    private bool isGrounded;

    public float groundRadius;

    public LayerMask whatisground;

    [SerializeField] private ParticleSystem particle;

    [SerializeField] private GameObject smoke;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        FlipJa();
        isGrounded = Physics2D.OverlapCircle(transform.position, groundRadius, whatisground);
        if (isGrounded)
        {
            anim.SetBool("jump",false);
        }
        else
        {
            anim.SetBool("jump",true);
        }
        AttackA();
    }
    //Maneja el movimiento del jugador
    private void MoveJA()
    {
        velX = Input.GetAxisRaw("Horizontal");
        velY = rb.velocity.y;
        rb.velocity = new Vector2(velX * speed, velY);
        if (rb.velocity.x != 0)
        {
            particle.Play();
            anim.SetBool("run",true);
        }
        else
        {
            anim.SetBool("run",false);
        }
    }
    //Volatea el sprite del jugador depende a la direccion que va el jugador
    private void FlipJa()
    {
        if (rb.velocity.x<0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            
        }else if (rb.velocity.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
           
        }
    }

    private void JumpJa()
    {
        if (Input.GetButton("Jump")&& isGrounded)
        {
            particle.Play();
            
            rb.velocity = new Vector2(rb.velocity.x, jumpH);
            
            
        }
       
       
        
    }

    private void AttackA()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Instantiate(smoke, transform.position, Quaternion.identity);
            anim.SetBool("attack",true);
        }
        else if (Input.GetKeyUp(KeyCode.E)) 
        {
            anim.SetBool("attack",false);
        }
    }
    
    private void FixedUpdate()
    {
        MoveJA();
        JumpJa();
       

       
    }
}
