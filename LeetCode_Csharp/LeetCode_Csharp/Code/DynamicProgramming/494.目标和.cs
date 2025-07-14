/*
 * @lc app=leetcode.cn id=494 lang=csharp
 *
 * [494] 目标和
 */

// @lc code=start
public partial class Solution
{
    public int FindTargetSumWays(int[] nums, int target)
    {
        int sum = 0;
        foreach (int i in nums) sum += i;
        // 如果为分数，肯定是组合不起来的，因为整数不论怎么加载一起都得不到小数
        if ((sum + target) % 2 == 1) return 0;

        // 1. dp 数组的定义
        int capacity = (sum + target) / 2;
        int[] dp = new int[capacity];

        // 2. 初始化 dp[0] 为 1，这里不能初始化为 0，初始化为 0 会导致
        // 后面的 dp 全部为 0
        // * 这里需要理解一下
        dp[0] = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            for (int j = capacity; j >= nums[i]; j--)
            {
                dp[j] += dp[j - nums[i]];
            }
        }
        return dp[capacity];
    }
}
// @lc code=end

