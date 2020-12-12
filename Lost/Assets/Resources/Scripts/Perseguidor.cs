using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidor : MonoBehaviour
{

    public float velocidadePerseguidor = 10f;
    public int damp = 2;

    [Header("Jugador")]
    private GameObject player;
    private Transform playerTrans;

    [Header("Hit")]
    public float hitDamage = 10f;
    private float hitCD = 2f;
    private float timeStamp;
    public float hitDistance = 5f;

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
            var temp = new Vector3(playerTrans.position.x, playerTrans.position.y + 1, playerTrans.position.z);

            if (Vector3.Distance(playerTrans.position, transform.position) < hitDistance)
            {
                if(timeStamp <= Time.time)
                {
                    player.GetComponent<LogicaPersonaje>().RecieveDamage(hitDamage);
                    timeStamp = Time.time + hitCD;
                }
            }
            else if (Vector3.Distance(playerTrans.position, transform.position) < 50)
            {
                Quaternion rotation = Quaternion.LookRotation(temp - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damp * Time.deltaTime);
                transform.Translate(0, 0, velocidadePerseguidor * Time.deltaTime);
            }
        }
    }
}