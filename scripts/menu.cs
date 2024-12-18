using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class menu : MonoBehaviour
{
    [Header("all menu")]
    public GameObject pausemenuui;
    public GameObject playerui;
    public static bool gameisstoped = false;


    public void resume()
    {
        pausemenuui.SetActive(false);
        playerui.SetActive(true);
        Time.timeScale = 1f;
        gameisstoped = false;
    }

    public void pause()
    {
        pausemenuui.SetActive(true);
        playerui.SetActive(false);
        Time.timeScale = 0f;
        gameisstoped = true;
    }

    public void restart()
    {
        SceneManager.LoadScene("scene_day");
        Time.timeScale = 1f;
    }

    public void loadmenu()
    {
        SceneManager.LoadScene("Garage");
        Time.timeScale = 1f;
    }
    public void quitgame()
    {
        Debug.Log("quitting game....");
        Application.Quit();
    }

}
