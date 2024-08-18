using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void About()
    {
        SceneManager.LoadScene("About");
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
