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

    private float maxMagSize = 15f;
    private float magSize;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        playerTrans = player.transform;
        magSize = maxMagSize;
    }

    // Update is called once per frame
    void Update()
    {
        var t = new Vector3(playerTrans.position.x, playerTrans.position.y + 1, playerTrans.position.z);
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(t - transform.position), 
                                              damp * Time.deltaTime);


        if (temp > 0)
        {
            temp -= Time.deltaTime;
        }
        else
        {
            if (Vector3.Distance(playerTrans.position, transform.position) < 70)
            {      
                if(magSize > 0)
                {
                    createAndShoot();
                    temp = 1.5f;
                } 
                else
                {
                    magSize = maxMagSize;
                    temp = 3f;
                }       
            }   
        }
    }

    private void createAndShoot()
    {
        GameObject b = Instantiate(bullet, transform.position, transform.rotation);
        b.GetComponent<Rigidbody>().AddForce(transform.forward * speed);
        b.transform.Rotate(90f, 0f, 0f, Space.Self);
        magSize -= 1;
    }
}






 