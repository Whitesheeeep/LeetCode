/*
 * @lc app=leetcode.cn id=279 lang=csharp
 *
 * [279] 完全平方数
 */

// @lc code=start
public partial class Solution
{
    public int NumSquares(int n)
    {
        if (n == 0) return 1;
        int maxItemN = 0;
        while (maxItemN * maxItemN < n)
        {
            maxItemN++;
        }
        if (maxItemN * maxItemN == n) return 1;
        else maxItemN--;

        // dp[j] 表示和为 n 的完全平方数的最小数量
        int[] dp = new int[n + 1];

        // 初始化
        for (int i = 0; i <= n; i++) dp[i] = n + 1;
        dp[0] = 1;

        for (int i = 1; i <= maxItemN; i++)
        {
            for (int j = i * i; j <= n; j++)
            {
                dp[j] = Math.Min(dp[j], dp[j - i * i] + 1);
            }
        }
        return dp[n];


    }
}
// @lc code=end

