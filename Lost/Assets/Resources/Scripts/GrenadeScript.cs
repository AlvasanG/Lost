using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeScript : MonoBehaviour
{

    public GameObject explosionEffect;
    public float delay = 8f; //Time for the grenade to explode if left unattended
    private AudioSource audio;
    public AudioClip clip;

    private float timeStamp;

    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        timeStamp = Time.time + delay;
    }

   void Update(){
        if(timeStamp <= Time.time){
            Explode();
        }
    }


    public void Explode(){
        GameObject clone = Instantiate(explosionEffect, transform.position, transform.rotation);
        audio.PlayOneShot(clip,1);
        ParticleSystem.MainModule particle = clone.GetComponent<ParticleSystem>().main;
        Destroy(clone, particle.duration);
        Destroy(gameObject);
    }
}
