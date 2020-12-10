using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidor : MonoBehaviour
{

    public float velocidadePerseguidor = 5f;
    public int damp = 2;

    [Header("Jugador")]
    private GameObject player;
    private Transform playerTrans;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTrans = player.transform;
    }

    void Update()
    {

        if (player != null)
        {

            if (Vector3.Distance(playerTrans.position, transform.position) < 50)
            {
                Quaternion rotation = Quaternion.LookRotation(playerTrans.position - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damp * Time.deltaTime);
                transform.Translate(0, 0, velocidadePerseguidor * Time.deltaTime);
            }
            else if (Vector3.Distance(playerTrans.position, transform.position) < 5)
            {
                print("Hit da playa");
            }
        }
    }
}