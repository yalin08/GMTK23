using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Pixelplacement;

public class GameOverUI : Singleton<GameOverUI>
{
    public GameObject LoseUI;


    public void RestartGame()
    {
        Debug.Log("hehehe");
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }

    public void ExitGame()
    {
        Application.Quit();
    }


}
