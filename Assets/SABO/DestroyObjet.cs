using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjet : MonoBehaviour
{
    // Start is called before the first frame update
    
    [SerializeField] private float time;
    void Start()
    {
        //Se utiliza para destruir un objeto despues de un tiempo
        Destroy(this.gameObject,time);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
