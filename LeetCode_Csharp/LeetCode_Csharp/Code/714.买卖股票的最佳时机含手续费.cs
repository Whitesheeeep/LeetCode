/*
 * @lc app=leetcode.cn id=714 lang=csharp
 *
 * [714] 买卖股票的最佳时机含手续费
 */

// @lc code=start
public partial class Solution {
    public int MaxProfitWithFee(int[] prices, int fee)
    {
        if (prices.Length <= 1) return 0;

        // 1：表示持有，2：不持有
        int[,] dp = new int[prices.Length, 3];
        // 初始化
        dp[0, 1] = -prices[0] - fee;

        for (int i = 1; i < prices.Length; i++)
        {
            dp[i, 1] = Math.Max(dp[i - 1, 1], dp[i - 1, 2] - prices[i] - fee);
            dp[i, 2] = Math.Max(dp[i - 1, 2], dp[i - 1, 1] + prices[i]);
        }
        return dp[prices.Length - 1, 2];
    }
}
// @lc code=end

