/*
 * @lc app=leetcode.cn id=474 lang=csharp
 *
 * [474] 一和零
 */

// @lc code=start
public partial class Solution
{
    public int FindMaxForm(string[] strs, int m, int n)
    {
        int[] zeroCount = new int[strs.Length], oneCount = new int[strs.Length];
        foreach (string str in strs)
        {
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '0') zeroCount[i]++;
                else oneCount[i]++;
            }
        }

        int[,] dp = new int[m + 1, n + 1];
        for (int i = 0; i < strs.Length; i++)
        {
            for (int j = m; j >= zeroCount[i]; j--)
            {
                for (int k = n; k >= oneCount[i]; k--)
                {
                    dp[j, k] = dp[j - zeroCount[i], k - oneCount[i]] + 1;
                }
            }
        }
        return dp[m, n];
    }
}
// @lc code=end

