/*
 * @lc app=leetcode.cn id=377 lang=csharp
 *
 * [377] 组合总和 Ⅳ
 */

// @lc code=start
public partial class Solution
{
    public int CombinationSum4(int[] nums, int target)
    {
        if (nums.Length == 0) return 0;

        int[] dp = new int[target + 1];
        dp[0] = 1;
        for (int j = 0; j <= target; j++)
        {
            for (int i = 0; i < nums.Length; i++)
            {
                if(j >= nums[i]) dp[j] += dp[j - nums[i]];
            }
        }
        return dp[target];
    }
}
// @lc code=end

