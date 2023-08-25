using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBackGame : MonoBehaviour
{
    public GameObject backgroundDarken;
    public GameObject particulaFaisca;
    public GameObject objectInteract;
    public GameObject puzzle;

    public void BackGame()
    {
        Player.instance.isInteraction = false;

        backgroundDarken.SetActive(false);

        //particulaFaisca.SetActive(false);
        //objectInteract.SetActive(false);
        //puzzle.SetActive(false);

        Destroy(particulaFaisca);
        Destroy(objectInteract);
        Destroy(puzzle);
    }
}
