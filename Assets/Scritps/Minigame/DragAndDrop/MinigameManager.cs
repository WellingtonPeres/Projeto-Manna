using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;
    public Transform slotsParent;
    public GameObject[] slotsArray;

    public int[] answerArray;

    private int count;

    bool equal;

    int requestedPosition;

    private void Awake() //Creates the manager instance and triggers the initialization of the array.
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        InitializeArray();
    }
    public void InitializeArray() //Creates an array with all item slots, all slots are children of the same gameObject
    {
        count = 0;
        slotsArray = new GameObject[slotsParent.childCount];
        for (int i = 0; i < slotsParent.childCount; i++)
        {
          slotsArray[i] = slotsParent.GetChild(count).gameObject;
          count++;
        }
    }
    public bool CompareSlots(int index) //Checks if a certain coordinate has an item or not.
    {
        try
        {
            if (slotsArray[index].transform.childCount <= 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        catch(IndexOutOfRangeException outOfRange)
        {
            Debug.Log(outOfRange);
            return false;
        }
       
    }
    public int GetPosition(GameObject self) //Searches the array for a certain item and returns its coordinates.
    {
        requestedPosition = 0;
        for (int i = 0; i < slotsParent.childCount; i++)
        {
          if(self == slotsArray[i])
          {
            requestedPosition = i;
          }
        }
        //Debug.Log(requestedPosition);
        return requestedPosition;
    }
    public void UpdateArray()
    {
        for (int i = 0; i < slotsParent.childCount; i++)
        {
                if (slotsArray[i].transform.childCount == 0)
                {
                    slotsArray[i].GetComponent<InventorySlot>().itemIndex = 0;
                }
        }
            equal = true;
        for (int i = 0; i < slotsParent.childCount; i++)
        {
          if (answerArray[i] != slotsArray[i].GetComponent<InventorySlot>().itemIndex)
            {
              equal = false;
            }
        }
        Debug.Log(equal);
    }

}
