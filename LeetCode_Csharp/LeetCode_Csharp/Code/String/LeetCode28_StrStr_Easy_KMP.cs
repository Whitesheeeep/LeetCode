using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.String
{
    public class LeetCode28_StrStr_Easy_KMP
    {
        // 这题不讲武德：KMP 算法
        // 时间复杂度：O(n + m)，n 为 haystack 的长度，m 为 needle 的长度
        public int StrStr(string haystack, string needle)
        {
            #region  求 needle 的 next 数组
            // 求 needle 的 next 数组
            int[] next = new int[needle.Length];
            // 当前共同前后缀的长度，同时也是指向前缀的下一个字符的指针，当然前缀为 0的时候，指向的是第一个字符
            // 同时也是 当前字符前面字符串的最大相同前后缀
            int prefix_len = 0;
            next[0] = 0;
            for (int i = 1; i < needle.Length; i++)
            {
                if (needle[i] == needle[prefix_len])
                {
                    prefix_len++;
                    next[i] = prefix_len;
                }
                else
                {
                    // prefix_len 为 0 时，说明当前前面的共同前后缀中的前缀的字符串中没有共同前后缀
                    if (prefix_len == 0)
                    {
                        next[i] = 0;
                    }
                    else
                    {
                        // i-- 是为了继续比较当前字符和前缀的下一个字符
                        prefix_len = next[prefix_len - 1];
                        i--;
                    }
                }
            }
            #endregion 求 needle 的 next 数组

            #region  求 haystack 和 needle 的匹配
            int b_ptr = 0, n_ptr = 0;
            while (b_ptr < haystack.Length && n_ptr < needle.Length)
            {
                if (haystack[b_ptr] == needle[n_ptr])
                {
                    b_ptr++;
                    n_ptr++;
                }
                else
                {
                    // 当前字符不匹配时，如果 n_ptr 为 0，说明当前字符和 needle 的第一个字符不匹配
                    // if(next[n_ptr - 1] != 0) n_ptr = next[n_ptr - 1];
                    // else b_ptr++;

                    if (n_ptr == 0) b_ptr++;
                    else n_ptr = next[n_ptr - 1];
                }
            }
            #endregion 求 haystack 和 needle 的匹配

            return n_ptr == needle.Length ? b_ptr - n_ptr : -1;
        }
    }
}
