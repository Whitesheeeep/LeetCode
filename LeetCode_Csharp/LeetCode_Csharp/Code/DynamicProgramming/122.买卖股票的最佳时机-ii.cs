/*
 * @lc app=leetcode.cn id=122 lang=csharp
 *
 * [122] 买卖股票的最佳时机 II
 */

// @lc code=start
public partial class Solution
{
    public int MaxProfitII(int[] prices)
    {
        // dp[,0] 表示持有股票所获得的最多的现金，dp[,1] 表示不持有股票所获得的最多的现金
        int[,] dp = new int[prices.Length, 2];
        dp[0, 0] -= prices[0];
        dp[0, 1] = 0;
        for (int i = 1; i < prices.Length; i++)
        {
            // 持有股票
            dp[i, 0] = Math.Max(dp[i - 1, 0], dp[i - 1, 1] - prices[i]);
            // 不持有
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 0] + prices[i]);
        }
        return dp[prices.Length - 1, 1];

    }
}
// @lc code=end

