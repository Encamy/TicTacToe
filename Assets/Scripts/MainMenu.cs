using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //private GameMode m_gamemode = GameMode.GameMode3x3;
    private GameMode m_gamemode = GameMode.GameMode7x7;

    public Toggle m_3x3Button;
    public Toggle m_7x7Button;

    public Toggle m_PvPButton;
    public Toggle m_PvEButton;

    void Start()
    {
        switch (m_gamemode)
        {
            case GameMode.GameMode3x3:
                m_3x3Button.isOn = true;
                break;
            case GameMode.GameMode7x7:
                m_7x7Button.isOn = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        SceneManager.LoadScene("3x3");
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public enum GameMode
    {
        GameMode3x3,
        GameMode7x7,
    }
}
