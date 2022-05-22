using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void BotonStart()
    {
        SceneManager.LoadScene("Game");
    }

    public void BotonHelp()
    {
        SceneManager.LoadScene("Ayuda");
    }

    public void BotonReturn()
    {
        SceneManager.LoadScene("Menu");
    }

    public void BotonQuit()
    {
        Debug.Log("Se cierra el juego");
        Application.Quit();
    }

}
