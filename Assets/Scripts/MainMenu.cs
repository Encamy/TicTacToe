using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private GameMode m_gamemode = GameMode.GameMode3x3;
    private EnemyMode m_enemymode = EnemyMode.PvP;

    public Toggle m_3x3Button;
    public Toggle m_5x5Button;
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
            case GameMode.GameMode5x5:
                m_5x5Button.isOn = true;
                break;
            case GameMode.GameMode7x7:
                m_7x7Button.isOn = true;
                break;
        }

        switch (m_enemymode)
        {
            case EnemyMode.PvP:
                m_PvPButton.isOn = true;
                break;
            case EnemyMode.PvE:
                m_PvEButton.isOn = true;
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayGame()
    {
        GlobalStorage storage = GlobalStorage.GetInstance();
        storage.SaveGameMode(m_gamemode);
        storage.SaveEnemyMode(m_enemymode);

        switch (m_gamemode)
        {
            case GameMode.GameMode3x3:
                SceneManager.LoadScene("3x3");
                break;
            case GameMode.GameMode5x5:
                SceneManager.LoadScene("5x5");
                break;
            case GameMode.GameMode7x7:
                SceneManager.LoadScene("7x7");
                break;
        }
    }

    public void ToggleButtonClick(Toggle button)
    {
        if (button == m_3x3Button)
        {
            m_gamemode = GameMode.GameMode3x3;
        }
        else if (button == m_5x5Button)
        {
            m_gamemode = GameMode.GameMode5x5;
        }
        else if (button == m_7x7Button)
        {
            m_gamemode = GameMode.GameMode7x7;
        }
        else if (button == m_PvPButton)
        {
            m_enemymode = EnemyMode.PvP;
        }
        else if (button == m_PvEButton)
        {
            m_enemymode = EnemyMode.PvE;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public enum GameMode
    {
        GameMode3x3,
        GameMode5x5,
        GameMode7x7,
    }

    public enum EnemyMode
    {
        PvP,
        PvE,
    }
}
