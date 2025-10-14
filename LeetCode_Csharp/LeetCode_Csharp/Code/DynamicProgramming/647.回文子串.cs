/*
 * @lc app=leetcode.cn id=647 lang=csharp
 *
 * [647] 回文子串
 */

// @lc code=start
public partial class Solution
{
    public int CountSubstrings(string s)
    {
        // dp[i,j] 表示的是 s[i..(j+1)] 是否是回文子串
        bool[,] dp = new bool[s.Length, s.Length];
        // for (int i = 0; i < s.Length; i++) dp[i, i] = true;

        int count = 0;
        for (int i = s.Length - 1; i >=0; i--)
        {
            for (int j = i; j < s.Length; j++)
            {
                // s[i] = s[j] 后三种情况：
                // (1) i == j (2) j - i = 1 (3) j - i > 1
                // 前两种情况直接就是 true （大前提 s[i] =s[j]）
                if (s[i] != s[j]) dp[i, j] = false;
                else
                {
                    if (j - i <= 1) {
                        dp[i, j] = true;
                        count++;
                    }
                    else
                    {
                        if (dp[i + 1, j - 1])
                        {
                            dp[i, j] = true;
                            count++;
                        }
                    }
                }
            }
        }

        return count;
    }
}
// @lc code=end

