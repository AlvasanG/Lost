using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    
    public CharacterController controller;

    private Vector3 move;
    float moveX;
    float moveZ;


    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    private float aux;
    private float timeSpeed;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;

    Vector3 velocity;


    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        //Comprobar si esta tocando el suelo
        checkIsGrounded();

        //movimiento personaje
        setAxisAndMove();

        //Btn Saltar
        JumpAction();

        //Btn agacharse
        BendAction();

        //Soltar btn agacharse
        GetUpAction();

        //Apretar btn sprint
        SprintAction();

        //Aplicar Gravedad
        Gravity();

        //Aplica el movimiento al player
        Move();
    }

    void checkIsGrounded()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void setAxisAndMove()
    {
        moveX = Input.GetAxis("Horizontal");
        moveZ = Input.GetAxis("Vertical");

        move = transform.right * moveX + transform.forward * moveZ; 
    }

    void Gravity()
    {
        velocity.y += gravity * Time.deltaTime;
    }

    void Move()
    {
        controller.Move(velocity * Time.deltaTime);
        controller.Move(move * speed * Time.deltaTime);
    }

    void JumpAction()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {

            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);

        }
    }

    void SprintAction()
    {
        if (Input.GetButtonDown("Fire3") && isGrounded && timeSpeed > 0)
        {
            speed = 18f;
        }
        else if (Input.GetButtonUp("Fire3"))
        {
            speed = 12f;
        }
    }

    void BendAction()
    {
        if (Input.GetButtonDown("Fire2") && isGrounded)
        {
            aux = controller.height;
            controller.height = aux / 2;
            speed = 8f;

        }
    }

    void GetUpAction()
    {
        if (Input.GetButtonUp("Fire2"))
        {
            aux = controller.height;
            controller.height = aux * 2;
            speed = 12f;
        }
    }
}
