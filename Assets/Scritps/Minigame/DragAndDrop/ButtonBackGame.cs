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
        backgroundDarken.SetActive(false);
        Destroy(particulaFaisca);
        Destroy(objectInteract);
        Destroy(puzzle);
    }
}
