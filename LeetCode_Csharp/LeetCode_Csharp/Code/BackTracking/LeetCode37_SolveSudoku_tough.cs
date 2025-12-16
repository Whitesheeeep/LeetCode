using System;
using System.Buffers;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode37_SolveSudoku_tough
    {
        List<HashSet<char>> row; // 每一行存在那些 char
        List<HashSet<char>> column; // 每一列存在那些 char
        List<List<HashSet<char>>> chunk; // 每个 3*3 存在那些 char
        static readonly char[] chars = ['1', '2', '3', '4', '5', '6', '7', '8', '9'];

        public void SolveSudoku(char[][] board)
        {
            row = new List<HashSet<char>>(9);
            column = new List<HashSet<char>>(9);
            chunk = new List<List<HashSet<char>>>(3);

            // 初始化 row 和 column
            for (int i = 0; i < 9; i++)
            {
                row.Add(new HashSet<char>());
                column.Add(new HashSet<char>());
            }

            // 初始化 chunk（3 × 3）
            for (int i = 0; i < 3; i++)
            {
                var chunkRow = new List<HashSet<char>>(3);
                for (int j = 0; j < 3; j++)
                    chunkRow.Add(new HashSet<char>());
                chunk.Add(chunkRow);
            }
            // 将已有的存进去
            // 读取初始棋盘
            for (int x = 0; x < 9; x++)
            {
                for (int y = 0; y < 9; y++)
                {
                    char c = board[x][y];
                    if (c != '.')
                    {
                        row[x].Add(c);
                        column[y].Add(c);
                        chunk[x / 3][y / 3].Add(c);
                    }
                }
            }
            BackTracking(board, 0, 0);
        }

        bool BackTracking(char[][] board, int x, int y)
        {
            if (x > 8 || y > 8)
            {
                return true;
            }

            if (board[x][y] != '.')
            {
                if (y == 8)
                {
                    return BackTracking(board, x + 1, 0);
                }
                else
                {
                    return BackTracking(board, x, y + 1);
                }

            }
            foreach (var item in chars)
            {
                if (!row[x].Contains(item) && !column[y].Contains(item) && !chunk[x / 3][y / 3].Contains(item))
                {
                    board[x][y] = item;
                    row[x].Add(item);
                    column[y].Add(item);
                    chunk[x / 3][y / 3].Add(item);
                    if (y == 8)
                    {
                        if (BackTracking(board, x + 1, 0)) return true;
                    }
                    else
                    {
                        if (BackTracking(board, x, y + 1))
                            return true;
                    }
                    board[x][y] = '.';
                    row[x].Remove(item);
                    column[y].Remove(item);
                    chunk[x / 3][y / 3].Remove(item);
                }
            }
            return false;


        }
    }
}
