/*
 * @lc app=leetcode.cn id=188 lang=csharp
 *
 * [188] 买卖股票的最佳时机 IV
 */

// @lc code=start
public partial class Solution
{
    public int MaxProfitIIII(int k, int[] prices)
    {
        if (prices.Length <= 1) return 0;
        int[,] profitsDp = new int[prices.Length, 2 * k + 1];
        // k 为奇数，k 表示第 k 次持有获取的利润
        // k + 1 表示第 k 次不持有获取的利润
        for (int i = 1; i < 2 * k; i += 2)
        {
            profitsDp[0, i] = -prices[0];
        }

        for (int i = 1; i < prices.Length; i++)
        {
            for (int j = 1; j < 2*k ; j += 2)
            {
                // 持有
                profitsDp[i, j] = Math.Max(profitsDp[i - 1, j], profitsDp[i-1, j-1] - prices[i]);
                // 不持有
                profitsDp[i, j + 1] = Math.Max(profitsDp[i - 1, j + 1], profitsDp[i - 1, j] + prices[i]);
            }
        }
        return profitsDp[prices.Length - 1, 2 * k];
    }
}
// @lc code=end

