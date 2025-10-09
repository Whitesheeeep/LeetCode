/*
 * @lc app=leetcode.cn id=309 lang=csharp
 *
 * [309] 买卖股票的最佳时机含冷冻期
 */

// @lc code=start
public partial class Solution
{
    public static int MaxProfitWithFroze(int[] prices)
    {
        if (prices.Length <= 1) return 0;

        // 四种状态: 1：持有，2：不持有，3：冷冻期
        int[,] dp = new int[prices.Length, 4];

        // 初始化
        dp[0, 1] = -prices[0];
        dp[0, 2] = 0;
        dp[0, 3] = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 3] - prices[i]);
            dp[i, 2] = Math.Max(dp[i - 1, 2], dp[i - 1, 1] + prices[i]);
            dp[i, 3] = Math.Max(dp[i - 1, 3], dp[i - 1, 2]);

            for (int j = 1; j < 4; j++)
            {
                System.Console.WriteLine(dp[i, j]);
            }
        }


        return Math.Max(dp[prices.Length - 1, 2], dp[prices.Length - 1, 3]);

    }
}
// @lc code=end

