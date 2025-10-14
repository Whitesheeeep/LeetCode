/*
 * @lc app=leetcode.cn id=72 lang=csharp
 *
 * [72] 编辑距离
 */

// @lc code=start
public partial class Solution
{
    public int MinDistance_2(string word1, string word2)
    {
        // dp[i,j] 表示 word1[..i-1] 与 word2[..(j-1)] 相互转换需要的最少操作次数
        int[,] dp = new int[word1.Length + 1, word2.Length + 1];

        // 初始化
        // dp[i,0] 应该是 i
        // dp[0,j] 应该是 j
        // dp[0,0] = 0
        for (int i = 0; i <= word1.Length; i++) dp[i, 0] = i;
        for (int i = 0; i <= word2.Length; i++) dp[0, i] = i;

        for (int i = 1; i <= word1.Length; i++)
        {
            for (int j = 1; j <= word2.Length; j++)
            {
                if (word1[i - 1] == word2[j - 1]) dp[i, j] = dp[i - 1, j - 1];
                else
                {
                    dp[i, j] = Math.Min(Math.Min(dp[i - 1, j], dp[i, j - 1]), dp[i - 1, j - 1]) + 1;
                }
            }
        }

        return dp[word1.Length, word2.Length];
    }
}
// @lc code=end

