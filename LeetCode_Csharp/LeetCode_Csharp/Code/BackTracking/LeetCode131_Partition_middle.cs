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
            BackTracking(s, 0);
            return res;

            void BackTracking(in string input, int startIndex)
            {
                
                if(startIndex == input.Length)
                {
                    res.Add([..path]);
                    return;
                }

                if(s.Length >= input.Length) return;

                for(int i = startIndex; i < s.Length; i++)
                {
                    if (IsHuiWenString(s, startIndex, i))
                {
                    path.Add(s[startIndex..(i+1)]);
                }
                    BackTracking(input,  i);
                    path.RemoveAt(path.Count  - 1);
                }
            }

            bool IsHuiWenString(string s, int start, int end)
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
