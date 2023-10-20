using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    public GameObject fuego;
    private Animator anim;
    public AudioClip fuegoS;
    private AudioSource music;
    public float velocity,time;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UseFire();
    }

    void UseFire()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(DispararConEspera());




        }
        else if(Input.GetKeyUp(KeyCode.Q))
        {
            anim.SetBool("fire",false);
        }

        
    }
    
    private IEnumerator DispararConEspera()
    {
        anim.SetBool("fire", true);
        yield return new WaitForSeconds(time);
        music.PlayOneShot(fuegoS);
        GameObject subFuego = Instantiate(fuego, transform.position, Quaternion.identity);
        if (transform.localScale.x < 0)
        {
            
            subFuego.GetComponent<Rigidbody2D>().AddForce(new Vector2(-velocity, 0f), ForceMode2D.Force);
            subFuego.transform.localScale = new Vector2(-1, -1);
        }
        else
        {
            subFuego.GetComponent<Rigidbody2D>().AddForce(new Vector2(velocity, 0f), ForceMode2D.Force);
        }
    }
}
