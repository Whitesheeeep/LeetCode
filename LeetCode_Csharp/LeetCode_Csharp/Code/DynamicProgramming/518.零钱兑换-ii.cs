/*
 * @lc app=leetcode.cn id=518 lang=csharp
 *
 * [518] 零钱兑换 II
 */

// @lc code=start
public partial class Solution
{
    public int Change(int amount, int[] coins)
    {
        if (coins.Length == 0) return 0;

        int[] dp = new int[amount + 1];
        dp[0] = 1;
        for (int i = 0; i < coins.Length; i++)
        {
            for (int j = coins[i]; j <= amount; j++)
            {
                dp[j] += dp[j - coins[i]];
            }
        }
        return dp[amount];
    }
}
// @lc code=end

