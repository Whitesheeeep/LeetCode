using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode93_RestoreIpAddress_middle
    {
        public IList<string> RestoreIpAddresses(string s)
        {
            List<string> path = [];
            List<string> res = [];
            if (s.Length < 4 || s.Length > 12) return res;
            BackTracking(s, path, res, 0);
            return res;
        }

        private void BackTracking(in string s, List<string> path, List<string> res, int startIndex)
        {
            if (startIndex >= s.Length && path.Count == 4)
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(path[0]);
                for (int i = 1; i < path.Count; i++)
                {
                    sb.Append('.');
                    sb.Append(path[i]);
                }
                res.Add(sb.ToString());
                return;
            }

            // 剪枝
            for (int i = startIndex; i < s.Length && path.Count < 4; i++)
            {
                if (s[startIndex] == '0' && i > startIndex) break;
                if (int.Parse(s[startIndex..(i + 1)]) > 255) break;
                // 是否满足条件
                path.Add(s[startIndex..(i + 1)]);
                BackTracking(s, path, res, i + 1);
                path.RemoveAt(path.Count - 1);
            }
        }


    }
}
