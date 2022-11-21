using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public void OnClickStartButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void OnClickQuitButton()
    {
        Application.Quit();
    }

    public void OnClickMenuButton()
    {
        SceneManager.LoadScene("Menu");
    }

}
