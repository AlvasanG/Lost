using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{


    [Header("Jugador")]
    private GameObject player;
    private Transform playerTrans;

    public int damp = 2;
    public GameObject projectile;
    public float speed = 20f;
    public float temp = 3.0f;

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
                print("BANG!!");

                GameObject instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);

                instantiatedProjectile.velocity = transform.TransformDirection(0, 0, speed);

                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
                temp = 3.0f;
            }   
        }
    }

    private GameObject createAndShoot()
    {
        GameObject bullet = Instantiate(projectile, transform.position, transform.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
    }
}






 