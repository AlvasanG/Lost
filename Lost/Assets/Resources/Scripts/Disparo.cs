using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disparo : MonoBehaviour
{


    public Transform Player;
    public int damp = 2;
    public Rigidbody projectile;
    public float speed = 20f;
    public float temp = 3.0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(Player.position - transform.position), 
                                              damp * Time.deltaTime);

        if (temp > 0)
        {
            temp -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(Player.position, transform.position) < 30)
            {
                Rigidbody instantiatedProjectile = Instantiate(projectile, transform.position, transform.rotation);

                instantiatedProjectile.velocity = transform.TransformDirection(0, 0, speed);

                Physics.IgnoreCollision(instantiatedProjectile.GetComponent<Collider>(), transform.root.GetComponent<Collider>());
                temp = 3.0f;
            }   
        }
    }
}






 