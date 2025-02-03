using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace LeetCode_Csharp.Code.HashTable
{
    #region 方法一：滑动窗口
    //逐个比较
    //时间复杂度：O(N*M)
    public class LeetCode438_FindAnagrams_middle
    {
        public IList<int> FindAnagrams(string s, string p)
        {
            List<int> res = new();
            for (int i = 0; i <= s.Length - p.Length; i++)
            {
                if (IsAnagram(s[i..(i + p.Length)], p))
                    res.Add(i);
            }
            return res;
        }

        public bool IsAnagram(string s, string t)
        {
            if (s.Length != t.Length)
            {
                return false;
            }
            int[] alphaCount = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                alphaCount[s[i] - 'a']++;
                alphaCount[t[i] - 'a']--;
            }
            foreach (int count in alphaCount)
            {
                if (count != 0)
                {
                    return false;
                }
            }
            return true;
        }
        #endregion 方法一：滑动窗口

        #region  方法一的优化 ver_1
        //时间复杂度：O(M+(n-m)*26)，M 为 p 的长度，n 为 s 的长度
        public IList<int> FindAnagrams1(string s, string p) 
        {
                int sLen = s.Length, pLen = p.Length;

                if (sLen < pLen) {
                    return new List<int>();
                }

                IList<int> ans = new List<int>();
                int[] sCount = new int[26];
                int[] pCount = new int[26];
                //时间复杂度：O(M)，M 为 p 的长度
                for (int i = 0; i < pLen; ++i) {
                    ++sCount[s[i] - 'a'];
                    ++pCount[p[i] - 'a'];
                }

                //Enumerable.SequenceEqual() 方法用于确定两个序列是否相等，时间复杂度为 O(n)      
                if (Enumerable.SequenceEqual(sCount, pCount)) {
                    ans.Add(0);
                }

                for (int i = 0; i < sLen - pLen; ++i) {
                    --sCount[s[i] - 'a'];
                    ++sCount[s[i + pLen] - 'a'];

                    if (Enumerable.SequenceEqual(sCount, pCount)) {
                        ans.Add(i + 1);
                    }
                }

                return ans;
        }
        #endregion 方法一的优化 ver1

        #region 方法二：滑动窗口+哈希表(优化)
        //时间复杂度：O(N)
        public IList<int> FindAnagrams2(string s, string p)
        {
            //提取出 p 中的字符及其个数
            int[] pCount = new int[26];
            List<int> res = new List<int>();
            int need = 0;
            foreach (char c in p)
            {
                pCount[c - 'a']++;
                need++;
            }

            //滑动窗口
            //初始化
            int tmp = 0;
            int[] tmpCount = new int[26];
            for (int i = 0; i < p.Length; i++)
            {
                tmpCount[s[i] - 'a']++;
                if (pCount[s[i] - 'a'] > 0 && 
                    tmpCount[s[i] - 'a'] <= pCount[s[i] - 'a'])
                    tmp++;
            }
            if (tmp == need) res.Add(0);


            for (int i = 1; i < s.Length - p.Length + 1; i++)
            {
                //删除旧字符
                if (tmpCount[s[i - 1] - 'a'] > 0 && 
                    tmpCount[s[i - 1] - 'a'] <= pCount[s[i - 1] - 'a']) tmp--;
                tmpCount[s[i - 1] - 'a']--;

                //添加新字符
                int right = i + p.Length - 1;
                tmpCount[s[right] - 'a']++;
                if (pCount[s[right] - 'a'] > 0 && 
                    tmpCount[s[right] - 'a'] <= pCount[s[i] - 'a'])
                    tmp++;

                if (tmp == need) res.Add(i);
            }

            return res;
        }
        #endregion 方法二：滑动窗口+哈希表(优化)
        #region 方法二的优化 ver_1
        //时间复杂度：O(n+m+Σ)
        public IList<int> FindAnagrams2_2(string s, string p) 
        {
                int sLen = s.Length, pLen = p.Length;

                if (sLen < pLen) {
                    return new List<int>();
                }

                IList<int> ans = new List<int>();
                int[] count = new int[26];
                for (int i = 0; i < pLen; ++i) {
                    ++count[s[i] - 'a'];
                    --count[p[i] - 'a'];
                }

                int differ = 0;
                for (int j = 0; j < 26; ++j) {
                    if (count[j] != 0) {
                        ++differ;
                    }
                }

                if (differ == 0) {
                    ans.Add(0);
                }

                for (int i = 0; i < sLen - pLen; ++i) {
                    if (count[s[i] - 'a'] == 1) {  // 窗口中字母 s[i] 的数量与字符串 p 中的数量从不同变得相同
                        --differ;
                    } else if (count[s[i] - 'a'] == 0) {  // 窗口中字母 s[i] 的数量与字符串 p 中的数量从相同变得不同
                        ++differ;
                    }
                    --count[s[i] - 'a'];

                    if (count[s[i + pLen] - 'a'] == -1) {  // 窗口中字母 s[i+pLen] 的数量与字符串 p 中的数量从不同变得相同
                        --differ;
                    } else if (count[s[i + pLen] - 'a'] == 0) {  // 窗口中字母 s[i+pLen] 的数量与字符串 p 中的数量从相同变得不同
                        ++differ;
                    }
                    ++count[s[i + pLen] - 'a'];
                    
                    if (differ == 0) {
                        ans.Add(i + 1);
                    }
                }

                return ans;
        }
        #endregion 方法二的优化 ver_1
    }
}
