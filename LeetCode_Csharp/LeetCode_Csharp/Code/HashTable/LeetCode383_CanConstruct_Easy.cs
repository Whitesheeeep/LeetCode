using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode383_CanConstruct_Easy
    {
        public bool CanConstruct(string ransomNote, string magazine)
        {
            if(ransomNote.Length > magazine.Length)
            {
                return false;
            }

            int[] alphaCount = new int[26];
            for(int i = 0; i < magazine.Length; i++)
            {
                alphaCount[magazine[i] - 'a']++;
                if(i < ransomNote.Length)
                {
                    alphaCount[ransomNote[i] - 'a']--;
                }
            }
            foreach(int count in alphaCount)
            {
                if(count < 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
