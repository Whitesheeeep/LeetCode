/*
 * @lc app=leetcode.cn id=322 lang=csharp
 *
 * [322] 零钱兑换
 */

// @lc code=start
using System.Globalization;

public partial class Solution
{
    public int CoinChange(int[] coins, int amount)
    {
        if (coins.Length == 0) return -1;

        int[,] dp = new int[coins.Length, amount + 1];

        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = 0; j <= amount; j++)
            {
                dp[i, j] = amount + 1;
            }
        }

        // dp 初始化
        for (int i = coins[0]; i <= amount; i++)
        {
            dp[0, i] = dp[0, i - coins[0]] + 1;
        }
        for (int i = 0; i < coins.Length; i++)
        {
            dp[i, 0] = 0;
        }

        for (int i = 1; i < coins.Length; i++)
            {
                for (int j = 0; j <= amount; j++)
                {
                    if (j < coins[i]) dp[i, j] = dp[i - 1, j];
                    else
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], dp[i, j - coins[i]]);
                    }
                }
            }

        return dp[coins.Length - 1, amount] == amount + 1 ? -1 : dp[coins.Length - 1, amount];
    }
}
// @lc code=end

