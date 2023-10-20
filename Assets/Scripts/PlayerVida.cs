using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerVida : MonoBehaviour
{
    public float vida;
    public float Maxvida;
    private Blink material;
    private bool imunidad;
    private SpriteRenderer sprite;
    public float enpujeX;
    public float enpujeY;
    private Rigidbody2D rb;
    public float timeImunidad;
    public Image healthImg;
    
    // Start is called before the first frame update
    void Start()
    {
        vida = Maxvida;
        material = GetComponent<Blink>();
        sprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        healthImg.fillAmount=vida/100;
        if (vida > Maxvida)
        {
            vida = Maxvida;
            
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy") && !imunidad)
        {

            vida -= other.GetComponent<Enemy>().daño;
            StartCoroutine(inmunidad());
            if (other.transform.position.x < transform.position.x)
            {
            
                rb.AddForce(new Vector2(enpujeX,enpujeY),ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-enpujeX,enpujeY),ForceMode2D.Force);
                
            }
            if (vida < 0)
            {
                print("GameOver");
            }
        }
    }

    IEnumerator inmunidad()
    {
        imunidad = true;
        sprite.material = material.blink;
        yield return new WaitForSeconds(timeImunidad);
        sprite.material = material.original;
        imunidad = false;
    }
}
