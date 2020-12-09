using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicaEsferasNPC : MonoBehaviour
{
    public LogicaNPC logicaNPC; // nombre de logicaNPC
    public AudioSource audioSource;
    public AudioClip audioClipEsferas;
    public AudioClip audioClipFin;
    
    private LogicaPersonaje jugador;

    // Start is called before the first frame update
    void Start()
    {
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaPersonaje>();
    }

    void OnTriggerEnter(Collider other)
    {
        // si chocamos con u Player
        if(other.tag == "Player")
        {
            //restamos
            logicaNPC.numDeObjetivos--;
            jugador.GetTextMainDialogue().GetComponent<Text>().text = "Recoge los objetivos mas adelante";
            jugador.GetTextMainDialogue().GetComponent<Text>().text += "\nRestantes: " + logicaNPC.numDeObjetivos;
            audioSource.PlayOneShot(audioClipEsferas);
            if(logicaNPC.numDeObjetivos <= 0)
            {
                audioSource.PlayOneShot(audioClipFin);
            }
            //desactivamos el objeto padre por si queremos seguir utilizandolo en otras misiones
            transform.parent.gameObject.SetActive(false);
        }
    }

}
