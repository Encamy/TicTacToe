using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainMenu;

public class GlobalStorage
{
    private static GlobalStorage m_instance;
    private GameMode m_gamemode;
    private EnemyMode m_enemymode = EnemyMode.PvP;

    public static GlobalStorage GetInstance()
    {
        if (m_instance == null)
        {
            m_instance = new GlobalStorage();
        }

        return m_instance;
    }

    private GlobalStorage()
    {
        Debug.Log("Global storage was created");
    }

    public void SaveGameMode(GameMode mode)
    {
        m_gamemode = mode;
    }

    public GameMode GetGameMode()
    {
        return m_gamemode;
    }

    public void SaveEnemyMode(EnemyMode mode)
    {
        m_enemymode = mode;
    }

    public EnemyMode GetEnemyMode()
    {
        return m_enemymode;
    }
}
