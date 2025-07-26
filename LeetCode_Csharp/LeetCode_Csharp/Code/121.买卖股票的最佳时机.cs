/*
 * @lc app=leetcode.cn id=121 lang=csharp
 *
 * [121] 买卖股票的最佳时机
 */

// @lc code=start
public partial class Solution
{
    public int MaxProfit(int[] prices)
    {
        int min;

        int[] dp = new int[prices.Length];
        dp[0] = 0;
        min = prices[0];
        for (int i = 1; i < prices.Length; i++)
        {
            dp[i] = Math.Max(dp[i - 1], prices[i] - min);
            min = Math.Min(min, prices[i]);
        }
        return dp[prices.Length - 1];
    }
}
// @lc code=end

