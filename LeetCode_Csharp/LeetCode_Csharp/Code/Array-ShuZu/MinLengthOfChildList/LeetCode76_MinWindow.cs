using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp
{
    public class LeeCode76_MinWindow
    {
        //76. 最小覆盖子串
        //给你一个字符串 S、一个字符串 T 。请你设计一种算法，可以在 O(m+n) 的时间复杂度内，
        //从字符串 S 里面找出：包含 T 所有字符的最小子串。
        //示例：
        //输入：S = "ADOBECODEBANC", T = "ABC"
        //输出："BANC"

        //思路：滑动窗口
        //时间复杂度：O(2n) 没有达到目标 O(m+n)
        //空间复杂度：O(m), m 为 t 中不同字符的个数
        //
        public string MinWindow(string s, string t)
        {
            //得到 need 的字典
            Dictionary<char, int> need = new Dictionary<char, int>();
            //得到 s 的字典
            foreach(char c in t)
            {
                if(need.ContainsKey(c))
                {
                    need[c]++;
                }
                else
                {
                    need.Add(c, 1);
                }
            }

            Dictionary<char, int> window = new Dictionary<char, int>();

            // 预处理 s
            /* int first = 0, last = s.Length - 1;
            for(int i = 0; i < s.Length; i++)
            {
                if(need.ContainsKey(s[i]))
                {
                    first = i;
                    break;
                }
            }
            for(int i = s.Length - 1; i >= 0; i--)
            {
                if(need.ContainsKey(s[i]))
                {
                    last = i;
                    break;
                }
            }
            s = s.Substring(first, last - first + 1); */


            int start = 0;
            string result = "";
            for(int end = 0; end < s.Length; end++)
            {
                //如果当前字符符合 t 中的字符
                if(need.ContainsKey(s[end]))
                {
                    if(window.ContainsKey(s[end]))
                    {
                        window[s[end]]++;
                        if(window[s[end]] > need[s[end]] && s[start] == s[end])
                        {
                            window[s[end]]--;
                            start++;
                        }
                    }
                    else
                    {
                        window.Add(s[end], 1);
                    }
                }
                

                //如果当前窗口已经包含了所有的 t 中的字符
                //缩小窗口
                while(CheckDict(ref need, ref window))
                {
                    if(result == "" || end - start + 1 < result.Length)
                    {
                        result = s.Substring(start, end - start + 1);
                    }

                    if(need.ContainsKey(s[start]))
                    {
                        window[s[start]]--;
                    }
                    start++;
                }
            }

            return result;
        }

        

        public bool CheckDict(ref Dictionary<char, int> need, ref Dictionary<char, int> window)
        {
            foreach (var item in need)
            {
                if (!window.ContainsKey(item.Key) || window[item.Key] < item.Value)
                {
                    return false;
                }
            }
            return true;
        }
    }
}

public class LeetCode76_MinWindow2
{
    public string MinWindow(string s, string t)
    {
        // 构建 need 字典
        Dictionary<char, int> need = new Dictionary<char, int>();
        foreach (char c in t)
        {
            need[c] = need.ContainsKey(c) ? need[c] + 1 : 1;
        }

        Dictionary<char, int> window = new Dictionary<char, int>();
        int valid = 0; // 记录当前窗口中符合条件的字符种类数
        int start = 0, minLength = int.MaxValue;
        int left = 0, right = 0;

        // 滑动窗口
        while (right < s.Length)
        {
            char c = s[right];
            right++; // 移动右边界

            // 更新窗口数据
            if (need.ContainsKey(c))
            {
                if (!window.ContainsKey(c))
                    window[c] = 0;
                window[c]++;
                if (window[c] == need[c])
                    valid++;
            }

            // 判断是否需要收缩窗口
            while (valid == need.Count)
            {
                // 更新最小窗口
                if (right - left < minLength)
                {
                    start = left;
                    minLength = right - left;
                }

                char d = s[left];
                left++; // 移动左边界

                // 更新窗口数据
                if (need.ContainsKey(d))
                {
                    if (window[d] == need[d])
                        valid--;
                    window[d]--;
                }
            }
        }

        return minLength == int.MaxValue ? "" : s.Substring(start, minLength);
    }
}

//最小滑动窗口
//Solution3
public class LeetCode76_MinWindow3 
{
    public string MinWindow(string s, string t) {
        int[] map = new int[128];
        foreach (var c in t)
        {
            map[c]++;
        }
        int left = 0;
        int right = 0;
        int count = t.Length;
        int minLen = int.MaxValue;
        int start = 0;
        while (right < s.Length)
        {
            if (map[s[right]] > 0)
            {
                count--;
            }
            map[s[right]]--;
            right++;
            while (count == 0)
            {
                if (right - left < minLen)
                {
                    minLen = right - left;
                    start = left;
                }
                if (map[s[left]] == 0)
                {
                    count++;
                }
                map[s[left]]++;
                left++;
            }
        }
        return minLen == int.MaxValue ? "" : s.Substring(start, minLen);
    }
}

public class LeetCode76_MinWindowReview
{
    public string MinWindow(string s, string t)
    {
        int[] dic = new int[128];

        // 统计 t 中每个字符出现的次数
        foreach (var c in t)
        {
            dic[c]++;
        }

        int left = 0, right = 0;
        // 记录窗口中已经包含了多少个 t 中的字符
        int count = t.Length;
        // 记录最小覆盖子串的起始索引及长度
        int start = 0;
        int minLen = int.MaxValue;

        while(right < s.Length)
        {
            if(dic[s[right]] > 0)
            {
                count--;
            }
            //不需要的字符，dic 中的值会小于 0
            dic[s[right]]--;
            right++;

            // 当窗口中包含了 t 中的所有字符时，开始收缩窗口
            while(count == 0)
            {
                // 更新最小覆盖子串
                if(right - left < minLen)
                {
                    start = left;
                    minLen = right - left;
                }

                // 移动左指针
                if(dic[s[left]] == 0)
                {
                    count++;
                }
                // 恢复 dic 中的数据
                // 1. 不能放在上面的 if 里面，因为 s 的 window 中可能含有某个字符的多个，减的时候会使得 dic 中的值为负数
                // 但是这个字符还是需要的，而在上面的 if 里面，只有当 dic 中的值为 0 时，才会 count++
                // 2. 不能放在上面的 if 之前，如果放在上面，可能会导致 s 中原本不属于 t 的字符数量先被加回 0，而
                // if 会把这个字符错当成 t 中的字符，导致逻辑错误
                dic[s[left]]++;
                left++;
            }
        }

        return minLen == int.MaxValue ? "" : s.Substring(start, minLen);
    }
}
