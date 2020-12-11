using System.Collections;
using UnityEngine;

public class FinishLevelTrench : MonoBehaviour
{

    public GameObject[] bunkersStanding;
    private BoxCollider col;
    private MainMenu menuBehaviour;

    // Start is called before the first frame update
    void Start()
    {
        bunkersStanding = GameObject.FindGameObjectsWithTag("Bunker");
        menuBehaviour = GameObject.FindWithTag("Menu").GetComponent<MainMenu>();
        col = GetComponent<BoxCollider>();
        col.isTrigger = false;
    }

    // Update is called once per frame
    void Update()
    {
        bunkersStanding = GameObject.FindGameObjectsWithTag("Bunker");
        if(bunkersStanding.Length == 0){
            col.isTrigger = true;
        }
    }

    void OnTriggerEnter (Collider other){
        if(other.tag == "Player"){
            menuBehaviour.EscenaJuego("Bosque");
        }
    }
}
