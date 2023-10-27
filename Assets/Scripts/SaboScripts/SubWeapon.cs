using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SubWeapon : MonoBehaviour
{
    private PlayerController playerController;
    [SerializeField] private GameObject fuego;
    [SerializeField] private Transform controladorDisparo;
    [SerializeField] private Transform fuegoPoint;
    [SerializeField] private GameObject[] bolasFuego;
    private Animator anim;
    public AudioClip fuegoS;
    private AudioSource music;
    public float velocity,time;
    // Start is called before the first frame update
    void Start()
    {
        music = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        playerController = GetComponent<PlayerController>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1") && playerController.CanAttack())
        {
            anim.SetBool("fire",true);
            UseFire();
        } else if (Input.GetButtonUp("Fire1") )
        {
            anim.SetBool("fire",false);
        }
      
       
    }
    //ATAQUE FUEGO

    void UseFire()
    {
        
        //Instantiate(fuego, controladorDisparo.position, controladorDisparo.rotation);
        bolasFuego[Find()].transform.position = fuegoPoint.position;
        bolasFuego[Find()].GetComponent<Proyectil>().SetDirection(Mathf.Sign(transform.localScale.x));
    }

    private int Find()
    {
        for (int i = 0; i < bolasFuego.Length; i++)
        {
            if (!bolasFuego[i].activeInHierarchy)
            {
                return i;
            }

        }
        return 0;
    }
    
    
    
}
