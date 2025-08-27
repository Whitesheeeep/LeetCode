/*
 * @lc app=leetcode.cn id=28 lang=csharp
 *
 * [28] 找出字符串中第一个匹配项的下标
 */

// @lc code=start
public partial class Solution
{
    public static int StrStr(string haystack, string needle)
    {
        int[] next = GetNext(needle).ToArray();
        
        int needlePtr = 0;
        for (int i = 0; i < haystack.Length; i++)
        {
            if (haystack[i] == needle[needlePtr])
            {
                needlePtr++;
                if (needlePtr == needle.Length)
                    return i;
            }
            else if (needlePtr > 0)
            {
                i--;
                needlePtr = next[needlePtr - 1];
            }
        }
        return -1;
    }

    static List<int> GetNext(string needle)
    {
        List<int> next = [];
        next.Add(0);

        int len = 0;
        for (int i = 1; i < needle.Length; i++)
        {
            if (needle[len] == needle[i])
            {
                len++;
                next.Add(len);
            }
            else
            {
                if(len == 0)
                {
                    next[i] = 0;
                }
                else
                {
                    len = next[len - 1];
                    i--;
                }
            }
        }

        return next;
    }
}
// @lc code=end

