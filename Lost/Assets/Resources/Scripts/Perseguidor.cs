using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguidor : MonoBehaviour
{

    public float velocidadePerseguidor = 5f;
    public Transform Player;
    public int damp = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        if (Player != null)
        {

            if (Vector3.Distance(Player.position, transform.position) < 50)
            {
                Quaternion rotation = Quaternion.LookRotation(Player.position - transform.position);

                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, damp * Time.deltaTime);
                transform.Translate(0, 0, velocidadePerseguidor * Time.deltaTime);
            }
        }
    }
}