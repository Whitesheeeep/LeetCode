/*
 * @lc app=leetcode.cn id=213 lang=csharp
 *
 * [213] 打家劫舍 II
 */

// @lc code=start
using System.Runtime.Intrinsics.Arm;

public partial class Solution
{
    public int Rob2(int[] nums)
    {
        if (nums.Length == 1) return nums[0];


        int money_1 = Stolen(nums, 0, nums.Length - 2);
        int money_2 = Stolen(nums, 1, nums.Length - 1);

        return Math.Max(money_1, money_2);

    }

    private int Stolen(in int[] nums, int startIndex, int endIndex)
    {
        if (endIndex - startIndex == 0) return nums[startIndex];
        
        int[] dp = new int[nums.Length];

        dp[startIndex] = nums[startIndex];
        dp[startIndex + 1] = Math.Max(nums[startIndex] ,nums[startIndex + 1]);
        // 判断头两个拿的是哪个

        for (int i = startIndex + 2; i <= endIndex; i++)
        {
            // dp[i] = Math.Max(dp[i - 1], dp[i - 2] + nums[i]);
            if (dp[i - 2] + nums[i] > dp[i - 1])
            {
                dp[i] = dp[i - 2] + nums[i];

            }
            else dp[i] = dp[i - 1];
        }

        return dp[endIndex];
    }
}
// @lc code=end

