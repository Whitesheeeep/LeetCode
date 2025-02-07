using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.String
{
    public class LeetCode459_RepeatedSubstringPattern_Easy
    {
        #region 暴力解法
        // 时间复杂度：O(n^2)
        // 空间复杂度：O(1)
        public bool RepeatedSubstringPattern(string s)
        {
            for (int i = 1; i * 2 <= s.Length; i++)
            {
                bool match = true;
                if (s.Length % i == 0)
                {
                    for (int j = i; j < s.Length; j++)
                    {
                        if (s[j] != s[j - i])
                        {
                            match = false;
                            break;
                        }
                    }
                }
                if (match) return true;
            }
            return false;
        }
        #endregion 暴力解法

        #region 模式匹配
        // 时间复杂度：O(n)
        // 空间复杂度：O(n)
        public bool RepeatedSubstringPattern2(string s)
        {
            return (s + s).Substring(1, 2 * s.Length - 2).Contains(s);
        }
        #endregion 模式匹配

        #region KMP 算法思想
        // 时间复杂度：O(n)
        // 空间复杂度：O(n)
        public bool RepeatedSubstringPattern3(string s)
        {
            // next 数组
            int[] next = new int[s.Length];
            // 初始化
            int prefix_len = 0; next[0] = 0;
            for (int i = 1; i < s.Length; i++)
            {
                if(s[i] == s[prefix_len])
                {
                    prefix_len++;
                    next[i] = prefix_len;
                }
                else
                {
                    if(prefix_len == 0) next[i] = 0;
                    else
                    {
                        prefix_len = next[prefix_len - 1];
                        i--;
                    }
                }
            }

            return next[s.Length - 1] > 0 && s.Length % (s.Length - next[s.Length - 1]) == 0;
        }
        #endregion KMP 算法思想
    }
}
