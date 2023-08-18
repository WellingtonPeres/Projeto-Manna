using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Layes Interactions With Player")]
    [SerializeField] private LayerMask layerInteractions;
    private float rayDirection;

    private bool interactButton;

    private void Update()
    {
        interactButton = Input.GetKeyDown(KeyCode.E);

        if (Physics.Raycast(transform.position, transform.position + Vector3.down * 15, layerInteractions) && interactButton)
        {
            Debug.Log("Interact");
        }
    }
}
