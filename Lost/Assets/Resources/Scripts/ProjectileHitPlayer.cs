using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHitPlayer : MonoBehaviour
{
    public float bulletDamage = 20f;
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            other.gameObject.GetComponent<LogicaPersonaje>().RecieveDamage(bulletDamage);
            Destroy(gameObject);
        }

        if(other.gameObject.name == "Terrain")
        {
            Destroy(gameObject);
        }

        if(other.tag == "terrain" || other.tag == "cover")
        {
            Destroy(gameObject);
        }
    }
}
