using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody playerRigidbody;

    [Header("Movement Settings")]
    public float movementSpeed = 3f;
    public float jumpStrength = 6f;

    //Stored values
    private Camera mainCamera;
    private Vector3 movementDirection;

    public void SetupBehaviour()
    {
        SetCamera();
    }

    void SetCamera()
    {
        mainCamera = Camera.main;
    }

    public void UpdateMovementData(Vector3 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    void FixedUpdate()
    {
        MoveThePlayer();
    }

    void MoveThePlayer()
    {
        Vector3 movement = CameraDirection(movementDirection) * movementSpeed * Time.deltaTime;
        playerRigidbody.MovePosition(transform.position + movement);
    }

    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;
        
        return cameraForward * movementDirection.z + cameraRight * movementDirection.x; 
   
    }

    public void Jump()
    {
        playerRigidbody.AddForce(new Vector3(0, jumpStrength, 0), ForceMode.Impulse);
    }
}
