﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RechargeGrenades : MonoBehaviour
{

    private GameObject player;
    public int nGrenades = 10;
    public int givenGrenadesPerTake = 2;

    void Start(){
        player = GameObject.FindWithTag("Player");
    }

    void Update(){
        if( nGrenades <= 0 ){
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.tag == "Player" && nGrenades > 0){
            player.GetComponent<LogicaPersonaje>().nGranadas += givenGrenadesPerTake;
            nGrenades -= givenGrenadesPerTake;
        }
    }
}
