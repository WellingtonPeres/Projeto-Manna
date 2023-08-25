using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;

    [Header("Player Settings")]
    [SerializeField] private float moveSpeed = 7;
    [SerializeField] private float playerRadiusCapsule = 0.7f;
    [SerializeField] private float playerHeightCapsule = 2f;
    private Vector3 moveDirection;
    private float moveDistance;

    [Header("Get GameInput Script")]
    [SerializeField] private GameInput gameInput;


    public bool isInteraction = false;

    private bool isWalking;

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 inputVector = gameInput.GetMovementVectorNormalized();

        moveDirection = new Vector3(inputVector.x, 0f, inputVector.y);
        moveDistance = moveSpeed * Time.deltaTime;
        bool canMove = !Physics.CapsuleCast(transform.position,
                                            transform.position + Vector3.up * playerHeightCapsule,
                                            playerRadiusCapsule,
                                            moveDirection,
                                            moveDistance);
        if (!canMove)
        {
            // Cannot move towards moveDiretion
            // Attempr only X movement
            Vector3 moveDiretionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position,
                                            transform.position + Vector3.up * playerHeightCapsule,
                                            playerRadiusCapsule,
                                            moveDiretionX,
                                            moveDistance);

            if (canMove)
            {
                // Can move only on the X
                moveDirection = moveDiretionX;
            }
            else
            {
                // Cannot move only on the X
                // Attempr only Z movement
                Vector3 moveDiretionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position,
                                                transform.position + Vector3.up * playerHeightCapsule,
                                                playerRadiusCapsule,
                                                moveDiretionZ,
                                                moveDistance);
                
                if (canMove)
                {
                    // Can move only on the Z
                    moveDirection = moveDiretionZ;
                }
                else
                {
                    // Cannot move only in any direction
                }
            }
        }

        if (canMove)
        {
            transform.position += moveDirection * moveDistance;
        }

        isWalking = moveDirection != Vector3.zero;

        float rotateSpeed = 10f;
        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotateSpeed);
    }

    public bool IsWalking()
    {
        return isWalking;
    }
}
