/*
 * @lc app=leetcode.cn id=516 lang=csharp
 *
 * [516] 最长回文子序列
 */

// @lc code=start
public partial class Solution
{
    public static int LongestPalindromeSubseq(string s)
    {
        int[,] dp = new int[s.Length, s.Length];

        for (int i = s.Length - 1; i >= 0; i--)
        {
            for (int j = i; j < s.Length; j++)
            {
                if (s[i] == s[j])
                {
                    if (j == i) dp[i, j] = 1;
                    else if (j - i == 1) dp[i, j] = 2;
                    else
                    {
                        dp[i, j] = dp[i + 1, j - 1] + 2;
                    }
                }
                else
                {
                    if (j - i == 1) dp[i, j] = 1;
                    else
                    {
                        dp[i, j] = Math.Max(dp[i + 1, j], dp[i, j - 1]);
                    }
                }
                System.Console.WriteLine($"{i},{j}:"+dp[i,j]);
            }
        }
        return dp[0, s.Length - 1];
    }
}
// @lc code=end

