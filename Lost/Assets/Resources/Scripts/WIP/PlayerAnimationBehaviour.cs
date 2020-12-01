using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : MonoBehaviour
{
    [Header("Component References")]
    public Animator playerAnimator;

    //Animation String IDs
    private int playerMovementAnimationVelX;
    private int playerMovementAnimationVelY;
    private int playerCrouchAnimationID;
    private int playerJumpingAnimationID;
    private int playerTouchGroundAnimationID;

    public void SetupBehaviour()
    {
        SetupAnimationsIDs();
    }

    void SetupAnimationsIDs()
    {
        playerMovementAnimationVelX = Animator.StringToHash("VelX");
        playerMovementAnimationVelY = Animator.StringToHash("VelY");
        playerCrouchAnimationID = Animator.StringToHash("agachado");
        playerJumpingAnimationID = Animator.StringToHash("salto");
        playerTouchGroundAnimationID = Animator.StringToHash("tocoSuelo");

    }

    public void UpdateMovementAnimation(float movementX, float movementY)
    {
        playerAnimator.SetFloat(playerMovementAnimationVelX, movementX);
        playerAnimator.SetFloat(playerMovementAnimationVelX, movementY);
    }

    public void UpdateCrouchAnimation(bool state)
    {
        playerAnimator.SetBool(playerCrouchAnimationID, state);
    }

    public void UpdateJumpingAnimation(bool state)
    {
        playerAnimator.SetBool(playerCrouchAnimationID, state);
    }

    public void UpdateTouchGroundAnimation(bool state)
    {
        playerAnimator.SetBool(playerTouchGroundAnimationID, state);
        playerAnimator.SetBool("tocoSuelo", state);
    }
}
