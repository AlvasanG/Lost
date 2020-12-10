using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{


    [Header("Jugador")]
    private GameObject player;
    private Transform playerTrans;

    public int damp = 1;
    public GameObject bullet;
    public float speed = 500f;
    public float temp = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTrans = player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(playerTrans.position - transform.position), 
                                              damp * Time.deltaTime);


        if (temp > 0)
        {
            temp -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(playerTrans.position, transform.position) < 30)
            {                
                createAndShoot();
                temp = 1.5f;
            }   
        }
    }

    private void createAndShoot()
    {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        b.transform.Rotate(90f, 0f, 0f, Space.Self);
    }
}






 