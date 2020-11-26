using System.Collections;
using UnityEngine;

public class FinishLevelTrench : MonoBehaviour
{

    public GameObject[] bunkersStanding;

    // Start is called before the first frame update
    void Start()
    {
        bunkersStanding = GameObject.FindGameObjectsWithTag("Bunker");
    }

    // Update is called once per frame
    void Update()
    {
        bunkersStanding = GameObject.FindGameObjectsWithTag("Bunker");
        if(bunkersStanding.Length == 0){
            Destroy(gameObject);
        }
    }
}
