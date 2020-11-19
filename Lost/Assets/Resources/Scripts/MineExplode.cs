using System;
using UnityEngine;

namespace ObjectCode
{
        
    public class MineExplode : MonoBehaviour
    {
        public GameObject explosionEffect;
        public GameObject mine;

        public float radius = 10f;
        public float explosionForce = 10f;

        private ObjectCode.TerrainFormer tFormer;

        private void Start() {
            tFormer = mine.AddComponent<ObjectCode.TerrainFormer>();
        }

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
                    tFormer.UpdateHeightTerrain();
                }
            }

            GameObject clone = Instantiate(explosionEffect, transform.position, transform.rotation);
            ParticleSystem.MainModule particle = clone.GetComponent<ParticleSystem>().main;
            Destroy(clone, particle.duration);
            Destroy(gameObject);
        }
    }

}