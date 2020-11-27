using System.Collections;
using UnityEngine;

public class FinishLevelTrench : MonoBehaviour
{

    public GameObject[] bunkersStanding;
    private BoxCollider collider;
    private MainMenu menuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        bunkersStanding = GameObject.FindGameObjectsWithTag("Bunker");
        menuBehaviour = GameObject.FindWithTag("Menu").GetComponent<MainMenu>();
        collider = GetComponent<BoxCollider>();
        collider.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        bunkersStanding = GameObject.FindGameObjectsWithTag("Bunker");
        if(bunkersStanding.Length == 0){
            collider.isTrigger = true;
        }
    }

    void OnTriggerEnter (Collider other){
        if(other.tag == "Player"){
            menuBehaviour.EscenaJuego("MenuFinal");
        }
    }
}
