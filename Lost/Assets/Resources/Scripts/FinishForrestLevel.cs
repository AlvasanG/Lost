using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishForrestLevel : MonoBehaviour
{    private MainMenu menuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        menuBehaviour = GameObject.FindWithTag("Menu").GetComponent<MainMenu>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            menuBehaviour.EscenaJuego("iglesia");
        }
    }
}
