using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlSonidos : MonoBehaviour
{
    private AudioSource sonido;
    public AudioClip mario;
    public AudioClip tiro;

    // Start is called before the first frame update
    void Start()
    {
        sonido = GetComponent<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) // comprueba la tecla W
        {
            sonido.clip = mario;
            sonido.Play();
        }

        if (Input.GetKeyDown(KeyCode.Q)) // comprueba la tecla Q
        {
            sonido.clip = tiro; 
            sonido.Play(); // Reproduce el sonido
        }
    }
}
