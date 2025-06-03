using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode738_MonotoneIncreasingDigits_middle
    {
        public int MonotoneIncreasingDigits(int n)
        {
            if (n < 10) return n;

            string s = n.ToString();
            int ptr = 0, up = 0;
            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] < s[i + 1])
                {
                    ptr = i+1;
                    up++;
                } 
                else if (s[i] > s[i + 1]) break;
                else up++;
            }
            if(up == s.Length - 1) return n;

            int res = ptr > 0 ? Int32.Parse(s[0..ptr]) * 10 + (s[ptr] - '0') - 1 : (s[ptr] - '0') - 1;
            for (int i = ptr + 1; i < s.Length; i++)
            {
                res = res * 10 + 9;
            }
            return res;
        }
    }
}
