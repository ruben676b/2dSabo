using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyHealth : MonoBehaviour
{
    private Enemy enemy;
    private Animator anim;
    private Rigidbody2D rb;
    public GameObject enemyDead;
    private bool isdamage;
    private bool isAttacking;
    private AudioSource music;
    public AudioClip daño, corte;

    private void Start()
    {
        music = GetComponent<AudioSource>();
        enemy = GetComponent<Enemy>();
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("weapon") && !isdamage)
        {
            music.PlayOneShot(daño);
            enemy.healthPoint -= 1f;
            if (other.transform.position.x < transform.position.x)
            {
                rb.AddForce(new Vector2(enemy.enpujeX, enemy.enpujeY), ForceMode2D.Force);
            }
            else
            {
                rb.AddForce(new Vector2(-enemy.enpujeX, enemy.enpujeY), ForceMode2D.Force);
            }
            StartCoroutine(Damager());
            if (enemy.healthPoint <= 0)
            {
                
                Instantiate(enemyDead, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Player"))
        {
            music.PlayOneShot(corte);
            isAttacking = true; 
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isAttacking = false; 
            anim.SetBool("attack", false);
        }
    }

    IEnumerator Damager()
    {
        anim.SetBool("daño", true);
        isdamage = true;
        yield return new WaitForSeconds(0.3f);
        isdamage = false;
        anim.SetBool("daño", false);
    }

    private void Update()
    {
        if (isAttacking)
        {
            
            anim.SetBool("attack", true);
        }
    }
}
