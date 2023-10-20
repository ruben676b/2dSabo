using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class Sonido : MonoBehaviour
{
    public AudioMixer efectos, music;

    public AudioSource dead, salto, corte, fuego,golpe,fondo;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }
  
    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAudio(AudioSource audio)
    {
        audio.Play();
    }
}
