/*
 * @lc app=leetcode.cn id=1049 lang=csharp
 *
 * [1049] 最后一块石头的重量 II
 */

// @lc code=start
public partial class Solution
{
    public int LastStoneWeightII(int[] stones)
    {
        if (stones.Length == 1) return stones[0];
        // 有贪心的思想，在平均线两边进行消除是最好的选择
        int sum = 0;
        foreach (int i in stones) sum += i;

        int target = sum / 2;
        int[] dp = new int[3000];
        for (int i = 0; i < stones.Length; i++)
        {
            for (int j = sum / 2; j >= stones[i]; j--)
                dp[j] = Math.Max(dp[j], dp[j - stones[i]] + stones[i]);
        }

        return sum - dp[sum / 2] - dp[sum / 2];
    }
}
// @lc code=end

