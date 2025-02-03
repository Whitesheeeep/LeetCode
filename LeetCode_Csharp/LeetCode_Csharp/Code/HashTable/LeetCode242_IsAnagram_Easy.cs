using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode242_IsAnagram_Easy
    {
        //时间复杂度：O(N)
        public static bool IsAnagram(string s, string t)
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
    }
}
