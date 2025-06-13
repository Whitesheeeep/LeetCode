using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode62_UniquePaths_middle
    {
        public int UniquePaths(int m, int n)
        {
            // 杨辉三角
            if (m <= 1 || n <= 1) return 1;
            int[,] dp = new int[m + n, m + n];
            dp[1, 1] = 1;
            for (int row = 2; row <= m + n - 1; row++)
            {
                for (int colume = 1; colume <= m+ n -1; colume++)
                {
                    if (colume == 1 || colume == m + n -1) dp[row, colume] = 1;
                    else
                    {
                        dp[row, colume] = dp[row - 1, colume] + dp[row - 1, colume - 1];
                    }
                }
            }
            return dp[n + m -1, m ];
        }
    }
}
