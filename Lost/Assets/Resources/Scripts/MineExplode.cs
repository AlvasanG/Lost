using System;
using UnityEngine;
using System.Collections;

namespace ObjectCode
{
        
    public class MineExplode : MonoBehaviour
    {
        public GameObject explosionEffect;
        public GameObject mine;

        public float radius = 10f;
        public float explosionForce = 10f;
        public float explosionDepth = 3f; // Altura del terreno debajo de la mina despues de que estalle (la playa es altura 5)

        private ObjectCode.TerrainFormer tFormer;

        private void Start() {
            tFormer = mine.AddComponent<ObjectCode.TerrainFormer>();
        }

        private void OnTriggerEnter(Collider other) {
            
            if(other.tag == "Player"){
                Explode();      
            }

        }

        private void Explode(){
            Collider[] colliders = Physics.OverlapSphere(transform.position, radius);

            foreach(Collider col in colliders){
                Rigidbody rig = col.GetComponent<Rigidbody>();
                if(rig != null){
                    // Realizar cualquier accion contra el jugador (col)
                    tFormer.SetDesiredHeight(explosionDepth);
                }
            }

            GameObject clone = Instantiate(explosionEffect, transform.position, transform.rotation);
            ParticleSystem.MainModule particle = clone.GetComponent<ParticleSystem>().main;
            Destroy(clone, particle.duration);
            Destroy(gameObject);
        }
    }

}