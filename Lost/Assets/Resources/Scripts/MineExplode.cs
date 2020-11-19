using System;
using UnityEngine;

public class MineExplode : MonoBehaviour
{
    public GameObject explosionEffect;

    public float radius = 10f;
    public float explosionForce = 10f;

    private void OnTriggerEnter(Collider other) {
        
        if(other.tag == "Player"){
            explosionEffect.SetActive(true);
            Explode();      
        }

    }

    private void Explode(){
        Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

        foreach(Collider col in colliders){
            Rigidbody rig = col.GetComponent<Rigidbody>();
            if(rig != null){
                // Realizar cualquier accion contra el jugador (col)
                rig.AddExplosionForce(explosionForce, transform.position, radius, 2f, ForceMode.Impulse); // La explosion te manda volando
            }
        }

        GameObject clone = Instantiate(explosionEffect, transform.position, transform.rotation);
        ParticleSystem.MainModule particle = clone.GetComponent<ParticleSystem>().main;
        Destroy(clone, particle.duration);
        Destroy(gameObject);
    }

}
