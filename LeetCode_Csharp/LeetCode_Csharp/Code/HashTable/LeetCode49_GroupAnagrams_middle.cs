using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode49_GroupAnagrams_middle
    {
        public IList<IList<string>> GroupAnagrams(string[] strs) 
        {
            List<IList<string>> res = new List<IList<string>>();
            foreach(var str in strs)
            {
                if(!ContainsAnagrams(res, str))
                {
                    res.Add(new List<string>(){str});
                }
            }
            return res;
        }

        private bool ContainsAnagrams(IList<IList<string>> res, string str)
        {
            foreach (var item in res)
            {
                if (LeetCode242_IsAnagram_Easy.IsAnagram(item[0], str))
                {
                    item.Add(str);
                    return true;
                }
            }
            return false;
        }

        #region 方法一：排序+哈希表
        public IList<IList<string>> GroupAnagrams2(string[] strs) 
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            foreach(var str in strs)
            {
                char[] charArray = str.ToCharArray();
                Array.Sort(charArray);
                string key = new string(charArray);
                if(dic.ContainsKey(key))
                {
                    dic[key].Add(str);
                }
                else
                {
                    dic.Add(key, new List<string>(){str});
                }
            }
            return dic.Values.ToArray();
        }

        public IList<IList<string>> GroupAnagrams3(string[] strs) 
        {
            Dictionary<string, List<string>> dic =[];
            foreach(var str in strs)
            {
                char[] chars = str.ToCharArray();
                //排序：采用快排，时间复杂度O(NlogN)
                Array.Sort(chars);
                string key = new(chars);
                if(dic.ContainsKey(key))
                {
                    dic[key].Add(str);
                }
                else
                {
                    dic.Add(key, new List<string>(){str});
                }
            }
            return dic.Values.ToArray();

        }
        #endregion 方法一：排序+哈希表

        #region 方法二：计数+哈希表
        public IList<IList<string>> GroupAnagrams4(string[] strs) 
        {
            Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
            foreach(var str in strs)
            {
                int[] count = new int[26];
                foreach(var c in str)
                {
                    count[c - 'a']++;
                }
                string key = string.Join("#", count);
                if(dic.ContainsKey(key))
                {
                    dic[key].Add(str);
                }
                else
                {
                    dic.Add(key, new List<string>(){str});
                }
            }
            return dic.Values.ToArray();
        }

        //时间复杂度：O(N(k+26))
        public IList<IList<string>> GroupAnagrams5(string[] strs) 
        {
            Dictionary<string, List<string>> dic = new();
            foreach(var str in strs)
            {
                //统计每个字符串中字符出现的次数
                //装载每个字符串的字符计数
                //时间复杂度：O(k)，k 是字符串的长度
                int[] count = new int[26];
                foreach(var c in str)
                {
                    count[c - 'a']++;
                }
                //将字符计数转换为字符串
                //时间复杂度：O(1)
                StringBuilder sb = new();
                for(int i = 0; i < 26; i++)
                {
                    if(count[i] != 0)
                    {
                        sb.Append((char)('a' + i));
                        sb.Append(count[i]);
                    }
                }

                //将字符串放入哈希表
                if(dic.ContainsKey(sb.ToString()))
                {
                    dic[sb.ToString()].Add(str);
                }
                else
                {
                    dic.Add(sb.ToString(), new List<string>(){str});
                }

            }

            return dic.Values.ToArray();
        }
        #endregion 方法二：计数+哈希表
    }
}
