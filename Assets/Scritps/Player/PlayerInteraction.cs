using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [Header("Layes Interactions With Player")]
    //public GameObject showTextInteractive; // Colocar um texto falando para precionar [E]
    public GameObject puzzleBackground;
    public GameObject puzzle; // GameObjct para ativar o puzzle correspondente a máquina

    private bool activeInteractButton = false;

    private void Update()
    {
        if (activeInteractButton && Input.GetKeyDown(KeyCode.E) && !Player.instance.isInteraction)
        {
            //showTextInteractive.SetActive(true);
            puzzleBackground.SetActive(true);
            puzzle.SetActive(true);

            Player.instance.isInteraction = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Entrei");
        activeInteractButton = true;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Sai");
        //showTextInteractive.SetActive(false);
    }
}
