using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;
using TMPro;

public class LogicaNPC : MonoBehaviour
{

    public GameObject simboloMision; // nuestro NPC va tener un simbolo arria
    public LogicaPersonaje jugador; // cuando hablemos al NPC necesitamos estar quietos
    public GameObject panelNPC; // interaccion
    public GameObject panelNPC2; // texto en sí
    public GameObject panelNPCMision; // panel que te sigue cuando aceptas la misision
    public TextMeshProUGUI textoMision; // el texto de la mision
    public bool jugadorCerca; // detecta cuando el personaje esta cerca
    public bool aceptarMision; // saber cuando acepta la mision
    public GameObject[] objetivos; // Arreglo 
    public int numDeObjetivos; // cuantos hay
    public GameObject botonDeMision; // cuando ya acabamos la msision

    public AudioSource audioSource;
    public AudioClip audioClipSaludo;

    // Start is called before the first frame update
    void Start()
    {
        numDeObjetivos = objetivos.Length; // cuantos objwtivos hay en el arreglo
        textoMision.text = "Obtén las esferas amarillas" +
                            "\n Restantes: " + numDeObjetivos;
        // detectamos el objeto con la etiqueta Player
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaPersonaje>();
        simboloMision.SetActive(true);
        panelNPC.SetActive(false);
        aceptarMision = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        // Si presionamos X, si aun no hemos aceptado la mision y si no estamos saltando 
        if(/*Input.GetKeyDown(KeyCode.X) ||*/ Input.GetButtonDown("Fire2") && aceptarMision == false && jugador.puedoSaltar == true && jugadorCerca)
        {
            // Nuestro personaje gire al NPC (para dar mas sensacion de realidad)
            Vector3 posicionJugador = new Vector3(transform.position.x, jugador.gameObject.transform.position.y, transform.position.z);
            jugador.gameObject.transform.LookAt(posicionJugador);
            // Queremos que los valores esten en 0
            jugador.anim.SetFloat("VelX", 0);
            jugador.anim.SetFloat("VelY", 0);
            // Deshabilitar el codigo
            //No usar para que el jugador tenga libertad
            jugador.enabled = false;
            // desactiva el presionar X
            panelNPC.SetActive(false);
            panelNPC2.SetActive(true);
        }
    }

    // cuando algo entre al area de la esfera del NPC
    private void OnTriggerEnter(Collider other)
    {
        // si el el player
        if(other.tag == "Player")
        {
            audioSource.PlayOneShot(audioClipSaludo);
            jugadorCerca = true; // el jugador esta cerca
            if(aceptarMision == false) // si aun no ha aceptado mision
            {
                panelNPC.SetActive(true);
            }
        }
    }

    // cuando salimos
    private void OnTriggerExit(Collider other)
    {
         // si el el player
        if(other.tag == "Player")
        {
            jugadorCerca = false; // el jugador no esta cerca
            
            
            panelNPC.SetActive(false);
            panelNPC2.SetActive(false);
        }
    }

    // si da no, desactiva todo
    public void No()
    {
        //No usar para que el jugador tenga libertad
        jugador.enabled = true;
        panelNPC2.SetActive(false);
        panelNPC.SetActive(true);

    }
    // si le damos a SI
    public void Si()
    {
         //No usar para que el jugador tenga libertad
        jugador.enabled = true;
        aceptarMision = true;
        //Recorremos el arreglo de objetivos
        for ( int i = 0; i < objetivos.Length ; i++)
        {
            // activa todas las esferas
            objetivos[i].SetActive(true);

        }
        jugadorCerca = false;
        simboloMision.SetActive(false);
        panelNPC.SetActive(false);
        panelNPC2.SetActive(false);
        panelNPCMision.SetActive(true); // solo acepta el de la mision
    }
}
