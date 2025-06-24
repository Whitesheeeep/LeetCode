using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.DynamicProgramming
{
    public class LeetCode63_UniquePathWithObstacles_middle
    {
        // Fixme-solved: 如果存在多个障碍物的时候，在累计 obstaclesRoutes 的时候会重复计算不同的障碍物之间的路径
        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            // 依然是dp 只不过就是减一下
            int[][] dp = new int[obstacleGrid.Length][];
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[obstacleGrid[0].Length];
            }


            // 存储 obstacles 的位置
            int row = dp.Length, colume = dp[0].Length;
            // dp 的初始化
            bool isObstacled = false;
            for (int i = 0; i < colume; i++)
            {
                if (obstacleGrid[0][i] == 1)
                {
                    isObstacled = true;
                }
                dp[0][i] = isObstacled? 0: 1;
            }
            isObstacled = false;
            for (int i = 0; i < row; i++)
            {
                if (obstacleGrid[i][0] == 1)
                {
                    isObstacled = true;
                }
                dp[i][0] = isObstacled? 0: 1;
            }
            for (int i = 1; i < row; i++)
            {
                for (int j = 1; j < colume; j++)
                {
                    if (obstacleGrid[i][j] == 1)
                    {
                        dp[i][j] = 0;
                        continue;   
                    }
                    dp[i][j] = dp[i - 1][j] + dp[i][j - 1];
                }
            }

            // // 统计总的障碍物所需要减去的路径的总数
            // int obstacleRoutes = 0;
            // for (int i = 0; i < obstacles.Count; i++)
            // {
            //     obstacleRoutes += dp[obstacles[i].m][obstacles[i].n] * dp[row - 1 - obstacles[i].m][colume - 1 - obstacles[i].n];
            // }


            return dp[row - 1][colume - 1];
        }
    }
}
