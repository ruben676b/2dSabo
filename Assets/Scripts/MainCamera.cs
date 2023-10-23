using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    [SerializeField] private GameObject Player;
    void Update()
    {
        Vector3 position = transform.position;
        position.x = Player.transform.position.x;
        float y = Player.transform.position.y;
        transform.position = position;

        if(y>3 && y<9)
        {
            position.y = Player.transform.position.y;
            transform.position = position;
        }
        
    }
}
