using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public GameObject Inicial;
    public GameObject Opcoes;
    public GameObject Creditos;

    public static Menu instance;
    private void Awake()
    {
        if (instance == null && SceneManager.GetActiveScene().buildIndex == 0)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        Inicial.SetActive(true);
        Opcoes.SetActive(false);
        Creditos.SetActive(false);
    }
    public void QuitGame()
    {
        AudioManager.instance.PlayConfirmSFX();
        Application.Quit();
    }
    public void ShowInicial()
    {
        AudioManager.instance.PlayConfirmSFX();
        Inicial.SetActive(true);
        Opcoes.SetActive(false);
        Creditos.SetActive(false);
    }
    public void ShowOpcoes()
    {
        AudioManager.instance.PlayConfirmSFX();
        Inicial.SetActive(false);
        Opcoes.SetActive(true);
        Creditos.SetActive(false);
    }
    public void ShowSelecao()
    {
        LoadGame();
    }
    public void ShowCreditos()
    {
        AudioManager.instance.PlayConfirmSFX();
        Inicial.SetActive(false);
        Opcoes.SetActive(false);
        Creditos.SetActive(true);
    }
    public void LoadGame()
    {
        AudioManager.instance.PlayConfirmSFX();
        SceneManager.LoadScene(1);
    }
}
