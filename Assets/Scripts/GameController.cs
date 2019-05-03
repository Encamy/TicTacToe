using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using static MainMenu;

public class GameController : MonoBehaviour
{
    public Player m_currentPlayer;
    public GameObject[] m_turnIcons;
    public Sprite m_XPlayerIcon;
    public Sprite m_OPlayerIcon;
    public Button[] m_tictactoeSpaces;
    private System.Random m_random;
    public Player[] m_cells;
    public GameObject[] m_winningLines;

    private int m_XPlayerScore;
    private int m_OPlayerScore;
    public Text m_XPlayerScoreText;
    public Text m_OPlayerScoreText;

    public Button m_rematchButton;

    public GameObject m_XWinnerImage;
    public GameObject m_OWinnerImage;

    public int m_turnCount;
    public Text m_WinnerText;

    private EnemyMode m_enemymode;

    // PvE region
    private Player m_AIplayer = Player.None;
    public GameObject m_XPlayer;
    public GameObject m_OPlayer;
    public GameObject m_YouPlayAs;

    // Start is called before the first frame update
    void Start()
    {
        GameSetup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void GameSetup()
    {
        m_random = new System.Random();
        m_currentPlayer = Player.XPlayer;
        m_turnIcons[0].SetActive(m_currentPlayer == Player.OPlayer);
        m_turnIcons[1].SetActive(m_currentPlayer == Player.XPlayer);

        m_cells = new Player[9];
        for (int i = 0; i < m_cells.Length; i++)
        {
            m_cells[i] = Player.None;
        }

        for (int i = 0; i < m_tictactoeSpaces.Length; i++)
        {
            m_tictactoeSpaces[i].interactable = true;
            m_tictactoeSpaces[i].GetComponent<Image>().sprite = null;
            
        }

        m_XWinnerImage.SetActive(false);
        m_OWinnerImage.SetActive(false);
        m_WinnerText.text = "Победитель!";

        m_turnCount = 0;

        GlobalStorage storage = GlobalStorage.GetInstance();
        m_enemymode = storage.GetEnemyMode();

        switch (storage.GetEnemyMode())
        {
            case EnemyMode.PvP:
                Debug.Log("Player vs Player");
                break;
            case EnemyMode.PvE:
                Debug.Log("Player vs AI");
                break;
        }

        if (m_enemymode == EnemyMode.PvE)
        {
            m_AIplayer = (m_random.Next() % 2 == 0) ? Player.OPlayer : Player.XPlayer;
            m_AIplayer = Player.OPlayer;
            if (m_AIplayer == Player.XPlayer)
            {
                m_XPlayer.SetActive(false);
                m_OPlayer.SetActive(true);
                m_YouPlayAs.SetActive(true);
            }
            else
            {
                m_OPlayer.SetActive(false);
                m_XPlayer.SetActive(true);
                m_YouPlayAs.SetActive(true);
            }
        }
        else if (m_enemymode == EnemyMode.PvP)
        {
            m_OPlayer.SetActive(false);
            m_XPlayer.SetActive(false);
            m_YouPlayAs.SetActive(false);
        }
    }

    public void TicTacToeButtonClick(int index)
    {
        TicTacToeButtonClick(index, false);
    }

    public void TicTacToeButtonClick(int index, bool force)
    {
        if (m_enemymode == EnemyMode.PvE)
        {
            if (m_currentPlayer == m_AIplayer && !force)
            {
                return;
            }
        }

        m_tictactoeSpaces[index].image.sprite = (m_currentPlayer == Player.XPlayer) ? m_XPlayerIcon : m_OPlayerIcon;
        m_tictactoeSpaces[index].interactable = false;

        m_cells[index] = m_currentPlayer;

        m_currentPlayer = (m_currentPlayer == Player.XPlayer) ? Player.OPlayer : Player.XPlayer;

        m_turnIcons[0].SetActive(m_currentPlayer == Player.OPlayer);
        m_turnIcons[1].SetActive(m_currentPlayer == Player.XPlayer);

        m_turnCount++;
        CheckWinner();

        if (m_enemymode == EnemyMode.PvE && m_currentPlayer == m_AIplayer)
        {
            CalculateAIMove();
        }
    }

    private void CalculateAIMove()
    {
        MiniMaxSolver miniMaxSolver = new MiniMaxSolver();
        int move = miniMaxSolver.GetNextMove(m_cells, m_AIplayer);
        TicTacToeButtonClick(move, true);
    }

    public void RematchButtonClick()
    {
        GameSetup();
        for (int i = 0; i < m_winningLines.Length; i++)
        {
            m_winningLines[i].gameObject.SetActive(false);
        }
        m_rematchButton.gameObject.SetActive(false);
    }

    public void CheckWinner()
    {
        WinnerLine line = CheckSpecificWinner(Player.OPlayer);

        if (line != WinnerLine.None)
        {
            m_OPlayerScore++;
            m_OPlayerScoreText.text = m_OPlayerScore.ToString();

            m_OWinnerImage.SetActive(true);

            ShowRematchButton(false);
        }

        if (line == WinnerLine.None)
        {
            line = CheckSpecificWinner(Player.XPlayer);

            if (line != WinnerLine.None)
            {
                m_XPlayerScore++;
                m_XPlayerScoreText.text = m_XPlayerScore.ToString();

                m_XWinnerImage.SetActive(true);

                ShowRematchButton(false);
            }
        }

        if (line == WinnerLine.None && m_turnCount >= 9)
        {
            ShowRematchButton(true);
        }
        
        DrawWinner(line);
    }

    private async Task ShowRematchButton(bool tie)
    {
        await Task.Delay(1000);
        m_rematchButton.gameObject.SetActive(true);
        if (tie)
        {
            m_WinnerText.text = "Ничья!";
        }
    }

    private void DrawWinner(WinnerLine line)
    {
        switch (line)
        {
            case WinnerLine.H1:
                m_winningLines[0].gameObject.SetActive(true);
                break;
            case WinnerLine.H2:
                m_winningLines[1].gameObject.SetActive(true);
                break;
            case WinnerLine.H3:
                m_winningLines[2].gameObject.SetActive(true);
                break;
            case WinnerLine.V1:
                m_winningLines[3].gameObject.SetActive(true);
                break;
            case WinnerLine.V2:
                m_winningLines[4].gameObject.SetActive(true);
                break;
            case WinnerLine.V3:
                m_winningLines[5].gameObject.SetActive(true);
                break;
            case WinnerLine.D1:
                m_winningLines[6].gameObject.SetActive(true);
                break;
            case WinnerLine.D2:
                m_winningLines[7].gameObject.SetActive(true);
                break;
        }
    }

    private WinnerLine CheckSpecificWinner(Player player)
    {
        if (m_cells[0] == player && m_cells[1] == player && m_cells[2] == player)
        {
            return WinnerLine.H1;
        }

        if (m_cells[3] == player && m_cells[4] == player && m_cells[5] == player)
        {
            return WinnerLine.H2;
        }

        if (m_cells[6] == player && m_cells[7] == player && m_cells[8] == player)
        {
            return WinnerLine.H3;
        }

        if (m_cells[0] == player && m_cells[3] == player && m_cells[6] == player)
        {
            return WinnerLine.V1;
        }

        if (m_cells[1] == player && m_cells[4] == player && m_cells[7] == player)
        {
            return WinnerLine.V2;
        }

        if (m_cells[2] == player && m_cells[5] == player && m_cells[8] == player)
        {
            return WinnerLine.V3;
        }

        if (m_cells[0] == player && m_cells[4] == player && m_cells[8] == player)
        {
            return WinnerLine.D1;
        }

        if (m_cells[2] == player && m_cells[4] == player && m_cells[6] == player)
        {
            return WinnerLine.D2;
        }

        return WinnerLine.None;
    }

    public enum Player
    {
        XPlayer,
        OPlayer,
        None
    }

    public enum WinnerLine
    {
        H1,
        H2,
        H3,
        V1,
        V2,
        V3,
        D1,
        D2,
        None
    }
}
