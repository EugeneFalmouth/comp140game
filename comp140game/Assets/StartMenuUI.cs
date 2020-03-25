using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuUI : MonoBehaviour
{   
    public void quickdrawClick()
    {
        Manager.choice = Manager.GameChoice.quickdraw;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void dogpileClick()
    {
        Manager.choice = Manager.GameChoice.dogpile;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void exitClick()
    {
        Application.Quit();
    }
}
