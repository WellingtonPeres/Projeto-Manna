using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigameManager : MonoBehaviour
{
    [Header("Slots for minegame")]
    public static MinigameManager instance;
     
    [Header("Slots dos Itens")]
    public Transform slotsParent;
    public GameObject[] slotsArray;

    [Header("Atualizar o texto de pontos do aluno")]
    public TextMeshProUGUI textMeshProUGUI;
    public int currentMinigamePoints;
    public int defaultMinigamePoints = 10;
    public int playerPoints;

    [Header("Time for correct answer")]
    public float timer;
    public float timerLenght;
    public float timerReward;
    public Image timerImage;

    [Header("Imagem De erro ou acerto da questão")]
    public GameObject[] ledDesligadas;
    public GameObject[] ledLigadas;
    public GameObject[] ledQueimadas;

    [Header("Quantidade de Slots existentes")]
    public int[] answerArray;
    int count;
    bool equal;
    int requestedPosition;

    [Header("Botão para sair do minigame e ocultar botão de verificação")]
    public GameObject buttonVerification;
    public GameObject buttonBackGame;

    // Sempre que interagir com uma máquina, ativar o puzzle referente a ela e ao finalizar destruir o Puzzle

    // Importar o Script do banco de dados
    [Header("Information for dada base")]
    //public Leaderboard leaderboard; ******************

    private bool correctAnswer = false;

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
        if (!correctAnswer)
        {
            timer -= Time.deltaTime;
            UpdateTimerReward();
        }
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

        ResetLeds(true);
        CorrectQuest(true, false);
        WrongQuest(true, false);

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

            // --------------- Informações para o banco de dados ---------------
            // Salvar "Nome da Escola", "Nickname", "Pontos"
            //StartCoroutine(leaderboard.SubmitScoreRoutine(playerPoints));******************
            correctAnswer = true;
            ResetMinigamePoints();
            UpdateTmpro();
            CorrectQuest(false, true);
        }
        else
        {
            if (currentMinigamePoints > 0)
            {
                currentMinigamePoints--;
            }
            UpdateTmpro();
            WrongQuest(false, true);
        }
    }

    public void UpdateTmpro()
    {
        textMeshProUGUI.text = $"Pontos por acertar: {playerPoints}";
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

    public void ResetLeds(bool activeLedDesligadas)
    {
        for (int i = 0; i < ledDesligadas.Length; i++)
        {
            ledDesligadas[i].SetActive(activeLedDesligadas);
        }
    }

    public void CorrectQuest(bool activeLedDesligadas, bool activeLedLigadas)
    {
        for (int i = 0; i < ledDesligadas.Length; i++)
        {
            ledDesligadas[i].SetActive(activeLedDesligadas);
            ledLigadas[i].SetActive(activeLedLigadas);
        }
    }

    public void WrongQuest(bool activeLedDesligadas, bool activeLedQueimadas)
    {
        for (int i = 0; i < ledDesligadas.Length; i++)
        {
            ledDesligadas[i].SetActive(activeLedDesligadas);
            ledQueimadas[i].SetActive(activeLedQueimadas);
        }
    }

    public void ShowButtonBackGame()
    {
        if (equal)
        {
            buttonVerification.SetActive(false);
            buttonBackGame.SetActive(true);
        }
    }
}