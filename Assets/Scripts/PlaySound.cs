using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    AudioSource fuenteAudio;

    public AudioClip gunSound;
    public AudioClip rifleSound;

    // Start is called before the first frame update
    void Start()
    {
        fuenteAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        // PISTOLA
        if (Input.GetKeyDown(KeyCode.A)) // si pulsamos la tecla "A"
        {
            fuenteAudio.clip = gunSound; // asignamos
            fuenteAudio.Play(); // ahora suena
        }

        // RIFLE
        if (Input.GetKeyDown(KeyCode.S)) // si pulsamos la tecla "S"
        {
            fuenteAudio.clip = rifleSound; // asignamos
            fuenteAudio.Play(); // ahora suena
        }
    }
}
