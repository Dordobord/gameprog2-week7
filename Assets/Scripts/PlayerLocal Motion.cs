using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLocalMotion : MonoBehaviour
{
    // Start is called before the first frame update
    Vector3 moveDirection;   
    Transform cameraObject;
    void Awake()
    {
        cameraObject = Camera.main.transform;
    }

    // Update is called once per frame
   
    public void HandleAllMovement()
    {
        HandleMovement();
        HandleRotation();
    }
    
    public void HandleMovement()
    {
        moveDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        moveDirection = moveDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        moveDirection.Normalize();
        moveDirection.y = 0;
        moveDirection *= global::PlayerManager.Instance.Movementspeed;
        Vector3 movementVelocity = moveDirection;
        PlayerManager.Instance.rigidBody.velocity = movementVelocity;
    }
    private void HandleRotation()
    {
        Vector3 targetDirection = Vector3.zero;
        targetDirection = cameraObject.forward * PlayerManager.Instance.inputManager.verticalInput;
        targetDirection = targetDirection + cameraObject.right * PlayerManager.Instance.inputManager.horizontalInput;
        targetDirection.Normalize();
        targetDirection.y = 0;

        if (targetDirection == )
            
        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        Quaternion playerRotation =
            Quaternion.Slerp
            (
                transform.rotation, targetRotation, global::PlayerManager.Instance.Rotatationspeed
            );

        transform.rotation = playerRotation;
    }
}
