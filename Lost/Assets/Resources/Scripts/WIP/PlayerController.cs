using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    [Header("Sub Behaviours")]
    private PlayerMovementBehaviour playerMovementBehaviour;
    private PlayerAnimationBehaviour playerAnimationBehaviour;

    [Header("Input Settings")]
    public PlayerInput playerInput;
    private Vector3 rawInputMovement;
    private Vector3 smoothInputMovement;
    private float movementSmoothingSpeed = 1f;

    [Header("Sound Settings")]
    private AudioSource audioSource;
    public AudioClip jump;
    public AudioClip walk;
    public AudioClip run;

    //Action Maps
    private string actionMapPlayer = "Player";

    //Stored values
    private string currentControlScheme;

    private bool isSprinting = false;
    private bool isCrouching = false;
    public bool canIJump = true;

    void Start()
    {
        currentControlScheme = playerInput.currentControlScheme;
        playerAnimationBehaviour = GetComponent<PlayerAnimationBehaviour>();
        playerMovementBehaviour = GetComponent<PlayerMovementBehaviour>();

        playerAnimationBehaviour.SetupBehaviour();
        playerMovementBehaviour.SetupBehaviour();
        SetAudioSource();
    }

    void SetAudioSource()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void PlaySound(AudioClip audio)
    {
        audioSource.clip = audio;
        audioSource.Play();
    }

    //INPUT SYSTEM ACTION METHODS ==============================

    //Player ActionMap

    public void OnMovement(InputAction.CallbackContext value) //Value is a Vector 2
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        rawInputMovement = new Vector3(inputMovement.x, 0f, inputMovement.y);
    }

    public void OnJump(InputAction.CallbackContext value) //Value is a button
    {
        if(value.started && canIJump)
        {
            playerAnimationBehaviour.UpdateJumpingAnimation(true);
            playerMovementBehaviour.Jump();
            PlaySound(jump);
        }
    }

    public void OnThrowGrenade(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            Debug.Log("Throwing a nade");
        }
    }

    public void OnCrouch(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            if(isCrouching)
            {
                Debug.Log("Stopped crouching");
            }
            else
            {
                Debug.Log("Started crouching");
            }
            isCrouching = !isCrouching;
        }
    }

    public void OnSprint(InputAction.CallbackContext value)
    {
        if(value.started)
        {
            if(isSprinting)
            {
                Debug.Log("Stopped sprinting");
            }
            else
            {
                Debug.Log("Started sprinting");
            }
            isSprinting = !isSprinting;
        }
    }


    //INPUT SYSTEM AUTOMATIC CALLBACKS ==============================

    //This is automatically called from PlayerInput, when the input device has changed
    public void OnControlsChanged()
    {
        if(playerInput.currentControlScheme != currentControlScheme)
        {
            currentControlScheme = playerInput.currentControlScheme;
        }
    }

    //This is automatically called from PlayerInput, when the input device has been disconnected and can not be identified
    public void OnDeviceLost()
    {
        Debug.Log("We lost our input " + currentControlScheme);
    }

    public void OnDeviceRegained()
    {
        Debug.Log("We regained our input " + currentControlScheme);
    }

    //Update Loop
    void Update()
    {
        CalculateMovementInputSmoothing();
        UpdatePlayerMovement();
        UpdatePlayerAnimationMovement();
    }

    void CalculateMovementInputSmoothing()
    {
        
        smoothInputMovement = Vector3.Lerp(smoothInputMovement, rawInputMovement, Time.deltaTime * movementSmoothingSpeed);

    }

    void UpdatePlayerMovement()
    {
        playerMovementBehaviour.UpdateMovementData(smoothInputMovement);
    }

    void UpdatePlayerAnimationMovement()
    {
        playerAnimationBehaviour.UpdateMovementAnimation(rawInputMovement.x, rawInputMovement.z);
        if(canIJump)
        {
            playerAnimationBehaviour.UpdateTouchGroundAnimation(false);
        }
    }
}
