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

    private LogicaPersonaje jugador;
    
    //public LogicaPersonaje logicaPersonaje; // Referencia al script de logica de nuestro peronaje

    // Start is called before the first frame update
    void Start()
    {
        // en un inicio busque los objetivos // length los cuentas
        numeroDeObjetivos = GameObject.FindGameObjectsWithTag("objetivo").Length;
        textoMision.text = "Obtén las esferas amarillas" + "\n Restantes: " + numeroDeObjetivos;
        jugador = GameObject.FindGameObjectWithTag("Player").GetComponent<LogicaPersonaje>();
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
            jugador.GetTextMainDialogue().GetComponent<Text>().text = "Recoge los objetivos mas adelante";
            jugador.GetTextMainDialogue().GetComponent<Text>().text += "\nRestantes: " + numeroDeObjetivos;
            audioSource.PlayOneShot(audioClipEsferas);
            // si no quedan objetivos
            if(numeroDeObjetivos<=0){
                audioSource.PlayOneShot(audioClipFin);
                StartCoroutine(MissionComplete());
            }
            
        }
    }

    IEnumerator MissionComplete()
    {
        jugador.GetTextMainDialogue().GetComponent<Text>().text = "Mision completada. Avanza hacia la zona de trincheras.";
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(5);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        jugador.GetTextMainDialogue().GetComponent<Text>().text = "";
    }
}
