using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Lamp : MonoBehaviour
{
    DraggableItem lampItem;
    public Image image;
    
    void Start()
    {
        lampItem = GetComponent<DraggableItem>();
    }

    void Update()
    {
        
    }
}
