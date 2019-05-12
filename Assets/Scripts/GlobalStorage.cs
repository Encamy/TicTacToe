using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MainMenu;

public class GlobalStorage
{
    private static GlobalStorage m_instance;
    private GameMode m_gamemode = GameMode.GameMode5x5;
    private EnemyMode m_enemymode = EnemyMode.PvE;
    private AI_Algorithm m_ai_algorithm = AI_Algorithm.ALPHA_BETA_PRUNING_TRANSPOSITION_TABLE_PARALLEL;
    //private AI_Algorithm m_ai_algorithm = AI_Algorithm.MINIMAX_SHORTEST_WAY;

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

    public AI_Algorithm GetAI_Algorithm()
    {
        return m_ai_algorithm;
    }

    public enum AI_Algorithm
    {
        MINIMAX,
        MINIMAX_SHORTEST_WAY,
        ALPHA_BETA_PRUNING,
        ALPHA_BETA_PRUNING_TRANSPOSITION_TABLE,
        ALPHA_BETA_PRUNING_TRANSPOSITION_TABLE_PARALLEL,
    }
}
