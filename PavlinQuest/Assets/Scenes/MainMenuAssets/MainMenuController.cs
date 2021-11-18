using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
 
public class MainMenuController : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene("GameScene");
    }

    public void AboutButton()
    {
        SceneManager.LoadScene("AboutPage");
    }

    public void exitGame()
    {
        Application.Quit();
    }
}