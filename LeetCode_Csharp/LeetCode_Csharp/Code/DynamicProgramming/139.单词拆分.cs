/*
 * @lc app=leetcode.cn id=139 lang=csharp
 *
 * [139] 单词拆分
 */

// @lc code=start
using System.Text;

public partial class Solution
{
    public bool WordBreak(string s, IList<string> wordDict)
    {
        // 这就是 dp
        string[] dp = new string[s.Length + 1];

        for (int j = 0; j <= s.Length; j++)
        {
            for (int i = 0; i <= wordDict.Count; i++)
            {
                if (j >= wordDict[i].Length)
                {
                    // 如果不拿
                    if (dp[j] != s.Substring(0,j))
                        dp[j] = dp[j - wordDict[i].Length] + wordDict[i];
                }
            }
        }
        
        return dp.Length == s.Length;
    }
}
// @lc code=end

