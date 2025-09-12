/*
 * @lc app=leetcode.cn id=300 lang=csharp
 *
 * [300] 最长递增子序列
 */

// @lc code=start
using Index = int;

public partial class Solution
{
    public int LengthOfLIS(int[] nums)
    {
        if (nums.Length == 1) return 1;
        int[] dp = new int[nums.Length];
        dp[0] = 1;

        int max = 0;
        for (int i = 1 ;i <nums.Length; i++)
        {
            dp[i] = 1;
            for (int j = 0; j < i; j++)
            {
                if(nums[j] < nums[i]) dp[i] = Math.Max(dp[i], dp[j] + 1);
            }

            max = Math.Max(max, dp[i]);
        }
        return max;
    }
}
// @lc code=end

