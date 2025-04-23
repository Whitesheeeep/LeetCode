using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode37_SolveSudoku_tough
    {

        public void SolveSudoku(char[][] board)
        {
            // 初始化
            bool[][] usedChars = new bool[9][];
            for(int i = 0; i < 9; i++)
            {
                usedChars[i] = new bool[9];
            }
        }

        public bool BackTracking(char[][] board, int row, bool[][] usedChars)
        {
            if(row == board.Length)
            {
                return true;
            }

            // 使用数组进行存储，index 代表这个数组对应的index的数值 代表的数字是否被占用
            for(int i = 0; i < 9; i++)
            {
                char temp = board[row][i];
                // 如果有数字，就存储，并且往下一列看
                if(temp != '.')
                {
                    usedChars[row][temp - '1'] = true;
                    continue;
                }

                // 这个格子是空的，填入逐个填入数字
                for(int j = 1; j <= 9; j++)
                {
                    // if(usedChars[row][i - 1] == true) continue;
                    if(!IsValid(usedChars,i)) continue;

                    usedChars[row][i-1] = true;
                    
                }
            }
            return false;
        }

        private bool IsValid(bool[][] usedChars, int i)
        {
            throw new NotImplementedException();
        }
    }
}
