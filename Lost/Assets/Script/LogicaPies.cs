using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public LogicaPersonaje logicaPersonaje;
    public AudioClip sonido;
    private AudioSource audio;
    

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

// Cuando detecte una mna reproduzca el sonido de una mina accionada
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mine")){
            audio.PlayOneShot(sonido, 1);
        }
    }
    private void OnTriggerStay() 
    {
        //if(other.tag == "terrain"){
            logicaPersonaje.puedoSaltar = true; 
        //}
           
    }

    private void OnTriggerExit() 
    {
        logicaPersonaje.puedoSaltar = false;    
    }
}
