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
    private object m_lock = new object();

    public TranspositionTable(int boardSize)
    {
        m_ZobristTable = new ulong[boardSize][];
        m_transpositions = new Dictionary<ulong, double>();

        for (int i = 0; i < boardSize; i++)
        {
            m_ZobristTable[i] = new ulong[2];

            m_ZobristTable[i][(int)Player.OPlayer] = generateHash();
            m_ZobristTable[i][(int)Player.XPlayer] = generateHash();
        }
    }

    public double GetTransposition(Player[] board)
    {
        lock (m_lock)
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
    }

    public void AddTransposotion(Player[] board, double score)
    {
        lock(m_lock)
        {
            ulong hash = computeHash(board);
            if (!m_transpositions.ContainsKey(hash))
            {
                m_transpositions.Add(hash, score);
            }
        }
    }

    private ulong computeHash(Player[] board)
    {
        ulong hash = 0;

        for (int i = 0; i < board.Length; i++)
        {
            if (board[i] != Player.None)
            {
                hash ^= m_ZobristTable[i][(int)board[i]];
            }
        }

        return hash;
    }

    private ulong generateHash()
    {
        byte[] byteContent = Encoding.Unicode.GetBytes(Guid.NewGuid().ToString());
        SHA256 hash = new SHA256CryptoServiceProvider();
        byte[] hashText = hash.ComputeHash(byteContent);

        ulong hashCodeStart = BitConverter.ToUInt64(hashText, 0);
        ulong hashCodeMedium = BitConverter.ToUInt64(hashText, 8);
        ulong hashCodeEnd = BitConverter.ToUInt64(hashText, 24);
        ulong hashCode = hashCodeStart ^ hashCodeMedium ^ hashCodeEnd;

        return hashCode;
    }
}
