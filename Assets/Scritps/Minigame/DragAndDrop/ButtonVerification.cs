using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonVerification : MonoBehaviour
{
    public void UpdateArray()
    {
        MinigameManager.instance.UpdateArray();
        MinigameManager.instance.AddSubtractPoints();
        MinigameManager.instance.ShowButtonBackGame();
    }
}
