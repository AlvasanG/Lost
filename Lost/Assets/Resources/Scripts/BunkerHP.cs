using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BunkerHP : MonoBehaviour
{
    public float health;
    public float maxHealth;


    public GameObject healthBarUI;
    public Slider hpBar;


    void Start(){
        health = maxHealth;
        hpBar.value = CalculateHealth();
    }

    void Update(){
        hpBar.value = CalculateHealth();

        if (health < maxHealth){
            healthBarUI.SetActive(true);
        }
        if(health <= 0){
            Destroy(gameObject);
        }

        if(health > maxHealth){
            health = maxHealth;
        }
    }

    float CalculateHealth(){
        return health / maxHealth;
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "grenade"){
            health -= (health/3);
        }
    }
}
