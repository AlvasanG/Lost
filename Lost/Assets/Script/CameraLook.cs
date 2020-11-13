using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CameraLook : MonoBehaviour
{

    public Transform playerBody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        float mouseY = Input.GetAxis("CamaraV");
        float mouseX = Input.GetAxis("CamaraH"); 

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);// no poder girar camara todos los grados en el arriba abajo
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);//movimiento camara arriba abajo

        playerBody.Rotate(Vector3.up * mouseX); // movimiento camara lados

    }
}
