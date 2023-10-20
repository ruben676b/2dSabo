using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public string nameE;
    public float healthPoint;
    public float speedE;
    public float enpujeX;
    public float enpujeY;
    public float daño;
    public Animator animE;
    void Start()
    {
        animE = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
