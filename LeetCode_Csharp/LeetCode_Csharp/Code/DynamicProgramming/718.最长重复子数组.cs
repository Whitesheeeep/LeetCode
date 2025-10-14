/*
 * @lc app=leetcode.cn id=718 lang=csharp
 *
 * [718] 最长重复子数组
 */

// @lc code=start
public partial class Solution
{
    public int FindLength(int[] nums1, int[] nums2)
    {
        int[,] dp = new int[nums1.Length + 1, nums2.Length + 1];
        int result = 0;
        for (int i = 1; i <= nums1.Length; i++)
        {
            for (int j = 1; j <= nums2.Length; j++)
            {
                if(nums1[i - 1] == nums2[j - 1]) dp[i, j] = dp[i - 1, j - 1] + 1;
                result = result < dp[i, j] ? dp[i, j] : result;
            }
        }
        return result;
    }
}
// @lc code=end

