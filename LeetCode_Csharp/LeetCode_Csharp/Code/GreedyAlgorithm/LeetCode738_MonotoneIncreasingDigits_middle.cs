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
            int tag = -1;
            char temp = '0';
            for (int i = 1; i < s.Length; i++)
            {
                if (s[i] < s[i - 1]) // 当递减的时候
                {
                    temp = s[i];
                    // 往前搜
                    while (i > 0 && temp < s[i - 1])
                    {
                        i--;
                        tag = i;
                    }
                    break;
                }
            }
            if (tag >= 0) // 存在递减
            {
                int res = 0;
                if (tag > 0) res = int.Parse(s[0..(tag - 1)]);
                res = res*10 + (temp - '0');
                for(int i = tag + 1; i < s.Length; i++)
                    res = res * 10 + 9;
                return res;
                
            }
            else return n;

        }
    }
}
