using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // propiedades del Canvas
using TMPro; //accede al texto y lo cambia
public class LogicaObjetivosEsferas : MonoBehaviour
{
    public int numeroDeObjetivos; // contabiliad los objetivo
    public TextMeshProUGUI textoMision; // cambiar el texto en el panel
    public GameObject botonDeMision; // se activa cuando la cantidad de objetivos llegue a 0
    public AudioSource audioSource;
    public AudioClip audioClipEsferas;
    public AudioClip audioClipFin;
    
    //public LogicaPersonaje logicaPersonaje; // Referencia al script de logica de nuestro peronaje

    // Start is called before the first frame update
    void Start()
    {
        // en un inicio busque los objetivos // length los cuentas
        numeroDeObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Obtén las esferas amarillas" + "\n Restantes: " + numeroDeObjetivos;
        //panel.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Cuando colisione con un trigger haga algo
    void OnTriggerEnter(Collider other)
    {
        // si choca con un tag objetivo
        if(other.gameObject.tag == "objetivo"){
            // Destruye al padre del objetivo
            Destroy(other.transform.parent.gameObject);
            numeroDeObjetivos--; // reducimos el numero de objetos
            textoMision.text = "Obtén las esferas amarillas" + "\n Restantes: " + numeroDeObjetivos;
            audioSource.PlayOneShot(audioClipEsferas);
            // si no quedan objetivos
            if(numeroDeObjetivos<=0){
                //logicaPersonaje.nivel++;
                textoMision.text = "Completaste la misión";
                botonDeMision.SetActive(true);
                audioSource.PlayOneShot(audioClipFin);

            }
            
        }
    }
}
