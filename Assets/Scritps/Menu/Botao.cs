using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao : MonoBehaviour
{
  public void showInicial()
    {
        Menu.instance.ShowInicial();
    }
    public void showSelecao()
    {
        Menu.instance.ShowSelecao();
    }
    public void showOpcoes()
    {
        Menu.instance.ShowOpcoes();
    }
    public void showCreditos()
    {
        Menu.instance.ShowCreditos();
    }
    public void quit()
    {
        Menu.instance.QuitGame();
    }
    public void play()
    {
        Menu.instance.LoadGame();
    }
}
