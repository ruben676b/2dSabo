using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    // Start is called before the first frame update
    private float speed;
    private Rigidbody2D rb;
    public bool isStatic;
    public bool isWalk;
    public bool isrigth;
    private Animator anim;
    public Transform pit, wall, groundC;
    private bool pitDe, wallDe, groundDe;
    public float radioDe;
    public LayerMask whatIsGround;
    public bool espera;
    public float TimeEspera;
    public bool isWait;

    public Transform puntoA, puntoB;
     bool goToA, goToB;
    public bool isPatr;
    void Start()
    {
        goToA = true;
        speed = GetComponent<Enemy>().speedE;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        pitDe = !Physics2D.OverlapCircle(pit.transform.position, radioDe, whatIsGround);
        wallDe = Physics2D.OverlapCircle(wall.transform.position, radioDe, whatIsGround);
        groundDe = Physics2D.OverlapCircle(groundC.transform.position, radioDe, whatIsGround);
        if ((pitDe || wallDe) && groundDe)
        {
            flip();
        }
    }

    private void flip()
    {
        isrigth = !isrigth;
        transform.localScale*=new Vector2(-1,transform.localScale.y);
    }
    private void FixedUpdate()
    {
        if (isWalk)
        {
            rb.constraints = RigidbodyConstraints2D.FreezeRotation;
            if (!isrigth)
            {
                rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                anim.SetBool("walk", true);
            }
            else
            {
                anim.SetBool("walk", true);
                rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
            }
        }
        else
        {
            anim.SetBool("walk", false); // Detener la animación de caminar
        }

        

        if (isPatr)
        {
            if (goToA)
            {
                if (!isWait)
                {
                    anim.SetBool("walk", true);
                    rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
                }
                if (Vector2.Distance(transform.position, puntoA.position) < 0.2f)
                {
                    if (espera)
                    {
                        StartCoroutine(Espera());
                    }
                    flip();
                    goToA = false;
                    goToB = true;
                }
            }
            if (goToB)
            {
                
                if (!isWait)
                {
                    anim.SetBool("walk", true);
                    rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
                }
                if (Vector2.Distance(transform.position, puntoB.position) < 0.2f)
                {
                    if (espera)
                    {
                        StartCoroutine(Espera());
                    }
                    flip();
                    goToA = true;
                    goToB = false;
                }
            }
        }
    }

    IEnumerator Espera()
    {
        anim.SetBool("walk",false);
        isWait = true;
        flip();
        yield return new WaitForSeconds(TimeEspera);
        anim.SetBool("walk",true);
        isWait = false;
        flip();
    }
}
