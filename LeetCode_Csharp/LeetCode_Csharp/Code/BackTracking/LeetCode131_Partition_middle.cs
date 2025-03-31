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
            BackTracking( 0);
            return res;

            void BackTracking(int startIndex)
            {
                
                if(startIndex == s.Length)
                {
                    res.Add([..path]);
                    return;
                }

                for(int i = startIndex; i < s.Length; i++)
                {
                    if (IsHuiWenString(s, startIndex, i))
                    {
                        path.Add(s[startIndex..(i+1)]);
                    }
                    else continue;
                    BackTracking( i+1);
                    path.RemoveAt(path.Count  - 1);
                }
            }

            bool IsHuiWenString(string s, int start, int end)
            {
                bool isHuiWen = true;
                for (int i = start, j = end; i < j; i++, j--)
                {
                    if (s[i] != s[j])
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
