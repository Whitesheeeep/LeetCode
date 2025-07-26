/*
 * @lc app=leetcode.cn id=198 lang=csharp
 *
 * [198] 打家劫舍
 */

// @lc code=start
using System.Runtime.Intrinsics.Arm;

public partial class Solution
{
    public int Rob(int[] nums)
    {
        if (nums.Length == 1) return nums[0];
        if (nums.Length == 2) return Math.Max(nums[0], nums[1]);

        int[] dp = new int[nums.Length];

        dp[0] = nums[0];
        dp[1] = Math.Max(nums[0], nums[1]);
        for (int i = 0; i < nums.Length; i++)
            dp[i] = Math.Max(nums[i] + dp[i - 2], dp[i - 1]);

        return dp[nums.Length - 1];

    }
}
// @lc code=end

