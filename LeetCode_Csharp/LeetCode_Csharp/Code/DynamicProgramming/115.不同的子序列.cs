/*
 * @lc app=leetcode.cn id=115 lang=csharp
 *
 * [115] 不同的子序列
 */

// @lc code=start
public partial class Solution {
    public int NumDistinct(string s, string t) {
        // dp[i,j] 表示 s[0..i-1] 中含有 t [0..j-1] 的个数
        int[,] dp = new int[s.Length + 1, t.Length + 1];
        // 初始化
        for (int j = 0; j <= t.Length; j++)
            dp[0, j] = 0;
        for (int i = 0; i <= s.Length; i++)
            dp[i, 0] = 1;

        for (int i = 1; i <= s.Length; i++)
        {
            for (int j = 1; j <= t.Length; j++)
            {
                if (s[i - 1] == t[j - 1]) dp[i, j] = dp[i - 1, j - 1] + dp[i - 1, j];
                else
                    dp[i, j] = dp[i - 1, j];
            }
        }
        return dp[s.Length, t.Length];
    }
}
// @lc code=end

