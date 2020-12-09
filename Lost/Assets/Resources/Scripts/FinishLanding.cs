using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishLanding : MonoBehaviour
{

    private LogicaPersonaje jugador;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaPersonaje>();
    }

    void OnTriggerEnter (Collider other){
        if(other.tag == "Player"){
            jugador.GetTextMainDialogue().SetActive(false);
            Destroy(gameObject);
        }
    }
}
