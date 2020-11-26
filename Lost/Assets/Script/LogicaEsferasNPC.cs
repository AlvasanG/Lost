using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicaEsferasNPC : MonoBehaviour
{
    public LogicaNPC logicaNPC; // nombre de logicaNPC
    public AudioSource audioSource;
    public AudioClip audioClipEsferas;
    public AudioClip audioClipFin;
    //public LogicaPersonaje logicaPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        // si chocamos con u Player
        if(other.tag == "Player")
        {
            //restamos
            logicaNPC.numDeObjetivos--;
            logicaNPC.textoMision.text = "Obtén las esferas amarillas" + 
            "\n Restantes: " + logicaNPC.numDeObjetivos;
            audioSource.PlayOneShot(audioClipEsferas);
            if(logicaNPC.numDeObjetivos <= 0)
            {
                logicaNPC.textoMision.text = "¡Completaste la misión!";
                logicaNPC.botonDeMision.SetActive(true);
                audioSource.PlayOneShot(audioClipFin);
                //logicaPersonaje.transform.position = new Vector3(590.45f,5.577601f,614.01f);

            }
            //desactivamos el objeto padre por si queremos seguir utilizandolo en otras misiones
            transform.parent.gameObject.SetActive(false);
        }
    }
}
