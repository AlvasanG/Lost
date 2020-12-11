using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishForrestLevel : MonoBehaviour

    private BoxCollider col;
    private MainMenu menuBehaviour;

{
    // Start is called before the first frame update
    void Start()
    {
        menuBehaviour = GameObject.FindWithTag("Menu").GetComponent<MainMenu>();
        col = GetComponent<BoxCollider>();
        col.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            menuBehaviour.EscenaJuego("Iglesia");
        }
    }
}
