using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigameManager : MonoBehaviour
{
    public static MinigameManager instance;
    public Transform slotsParent;
    public GameObject[] slotsArray;

    public int[] answerArray;

    private int count;

    bool equal;

    int requestedPosition;

    public TextMeshProUGUI textMeshProUGUI;
    public int currentMinigamePoints;
    public int defaultMinigamePoints;
    public int playerPoints;

    public float timer;
    public float timerLenght;
    public float timerReward;
    public Image timerImage;

    private void Awake() //Creates the manager instance and triggers the initialization of the array.
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        InitializeArray();
        ResetMinigamePoints();
        ResetTimer();
    }
    private void Update()
    {
        timer -= Time.deltaTime;
        UpdateTimerReward();
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
        catch (IndexOutOfRangeException outOfRange)
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
            if (self == slotsArray[i])
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
    public void AddSubtractPoints()
    {
        if (equal)
        {
            playerPoints += currentMinigamePoints;
            AddTimerPoints();
            ResetMinigamePoints();
            UpdateTmpro();
        }
        else
        {
            if (currentMinigamePoints > 0)
            {
                currentMinigamePoints--;
            }
            UpdateTmpro();
        }
    }
    public void UpdateTmpro()
    {
        textMeshProUGUI.text = $"{playerPoints}";
    }
    public void ResetMinigamePoints()
    {
        currentMinigamePoints = defaultMinigamePoints;
    }
    public void ResetTimer()
    {
        timer = timerLenght;
    }
    public void AddTimerPoints()
    {
        if (timer > 0)
        {
            playerPoints += (int)timerReward;
        }
    }
    public void UpdateTimerReward()
    {
        if (timer > 0)
        {
            timerImage.fillAmount = timer / timerLenght;
            if (Mathf.Round(timer) % 15 == 0)
            {
                timerReward = Mathf.Round(timer) / 15;
            }
        }
    }

}