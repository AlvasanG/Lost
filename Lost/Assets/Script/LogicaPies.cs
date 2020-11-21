using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaPies : MonoBehaviour
{
    public LogicaPersonaje logicaPersonaje;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    

    private void OnTriggerStay() 
    {
        logicaPersonaje.puedoSaltar = true;    
    }

    private void OnTriggerExit() 
    {
        logicaPersonaje.puedoSaltar = false;    
    }
}
