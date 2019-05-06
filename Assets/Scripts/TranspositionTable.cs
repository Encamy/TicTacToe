using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static GameController;

public class TranspositionTable
{
    private ulong[][] m_ZobristTable;
    private Dictionary<ulong, double> m_transpositions;

    public TranspositionTable(int boardSize)
    {
        m_ZobristTable = new ulong[boardSize][];
        m_transpositions = new Dictionary<ulong, double>();

        for (int i = 0; i < boardSize; i++)
        {
            m_ZobristTable[i] = new ulong[3];

            m_ZobristTable[i][(int)Player.None] = generateHash();
            m_ZobristTable[i][(int)Player.OPlayer] = generateHash();
            m_ZobristTable[i][(int)Player.XPlayer] = generateHash();
        }
    }

    public double GetTransposition(Player[] board)
    {
        ulong hash = computeHash(board);
        if (m_transpositions.ContainsKey(hash))
        {
            return m_transpositions[hash];
        }
        else
        {
            return -1;
        }
    }

    public void AddTransposotion(Player[] board, double score)
    {
        ulong hash = computeHash(board);
        if (!m_transpositions.ContainsKey(hash))
        {
            m_transpositions.Add(hash, score);
        }
    }

    private ulong computeHash(Player[] board)
    {
        ulong hash = 0;

        for (int i = 0; i < board.Length; i++)
        {
            hash ^= m_ZobristTable[i][(int)board[i]];
        }

        return hash;
    }

    private ulong generateHash()
    {
        byte[] bytes = new byte[64];
        using (var rng = new RNGCryptoServiceProvider())
        {
            rng.GetBytes(bytes);
        }

        return BitConverter.ToUInt64(bytes, 0);
    }
}
