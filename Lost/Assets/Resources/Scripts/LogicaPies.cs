using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public LogicaPersonaje logicaPersonaje;
    public AudioClip sonido;
    private AudioSource audioS;
    

    // Start is called before the first frame update
    void Start()
    {
        audioS = GetComponent<AudioSource>();
        if(logicaPersonaje == null)
            logicaPersonaje = transform.parent.gameObject.GetComponent<LogicaPersonaje>();  
    }

// Cuando detecte una mna reproduzca el sonido de una mina accionada
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Mine")){
            audioS.PlayOneShot(sonido, 1);
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
