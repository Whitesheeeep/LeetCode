using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode131_Partition_middle
    {
        List<string> path;
        List<IList<string>> res;
        public IList<IList<string>> Partition(string s)
        {
            path = new();
            res = new();
            BackTracking(s, "");
            return res;

            void BackTracking(in string input, string s)
            {
                if (IsHuiWenString(s))
                {
                    
                }
                if(s.Length >= input.Length) return;

                for(int i = 0; i < s.Length; i++)
                {
                    BackTracking(input, s + s[i]);
                }
            }

            bool IsHuiWenString(string s)
            {
                bool isHuiWen = true;
                for (int i = 0; i < s.Length / 2; i++)
                {
                    if (s[i] != s[^(i + 1)])
                    {
                        isHuiWen = false;
                        break;
                    }
                }
                return isHuiWen;
            }
        }
    }
}
