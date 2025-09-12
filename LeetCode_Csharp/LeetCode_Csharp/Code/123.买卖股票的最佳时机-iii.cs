/*
 * @lc app=leetcode.cn id=123 lang=csharp
 *
 * [123] 买卖股票的最佳时机 III
 */

// @lc code=start
public partial class Solution
{
    public int MaxProfitIII(int[] prices)
    {
        if (prices.Length <= 1) return 0;
        int[,] dp = new int[prices.Length, 5];
        // 初始化
        // 状态定义: dp[i][j] 表示第i天结束时的最大利润
        // j=0: 未进行任何交易
        // j=1: 第一次买入后持有
        // j=2: 第一次卖出后不持有
        // j=3: 第二次买入后持有
        // j=4: 第二次卖出后不持有

        dp[0, 0] = 0;
        dp[0, 1] = -prices[0];
        dp[0, 2] = 0;
        dp[0, 3] = -prices[0];
        dp[0, 4] = 0;

        for (int i = 1; i < prices.Length; i++)
        {
            // dp[i, 0] = dp[i - 1, 0]; // 不交易
            dp[i, 1] = Math.Max(dp[i - 1, 1], 0 - prices[i]); // 第一次买入
            dp[i, 2] = Math.Max(dp[i - 1, 2], dp[i - 1, 1] + prices[i]); // 第一次卖出
            dp[i, 3] = Math.Max(dp[i - 1, 3], dp[i - 1, 2] - prices[i]); // 第二次买入
            dp[i, 4] = Math.Max(dp[i - 1, 4], dp[i - 1, 3] + prices[i]); // 第二次卖出
        }
        return dp[prices.Length - 1, 4];
    }
}
// @lc code=end

