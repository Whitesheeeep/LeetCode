using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode332_FindItinerary_tough
    {
        List<string> path;
        List<string> res;
        bool[] used;
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            path = ["JFK"];
            res = new();
            used = new bool[tickets.Count];
            BackTracking(tickets);
            res = MinPath();
            return res;
        }

        private void BackTracking(IList<IList<string>> tickets)
        {
            if (path.Count == tickets.Count + 1)
            {
                res = [.. path];
                return;
            }

            string compare = "";
            
            // ! 错误点：前面的那一个可能是没有结果的但是大小是比后者小的
            for (int i = 0; i < tickets.Count; i++)
            {
                if (path.Count <= 1 && tickets[i][0] != "JFK") continue; // 保证第一张票由 JFK 开始
                if (used[i] == true) continue; // 如果票已经用过，跳过
                if (path.Last() != tickets[i][0]) continue; // 如果票对不上，就跳过
                if(compare != "" && res.Count != 0 && CompareString(compare, tickets[i][1])) continue;
                compare = tickets[i][1];

                path.Add(tickets[i][1]);
                used[i] = true;
                BackTracking(tickets);
                used[i] = false;
                path.RemoveAt(path.Count - 1);
            }
        }

        private bool CompareString(string first, string second)
        {
            for(int i = 0; i < 3; i++)
            {
                if(first[i] == second[i]) continue;
                if(first[i] > second[i]) return false;
                if(first[i] < second[i]) return true;
            }
            return true;
        }

        /* private List<string> MinPath()
        {

        } */
    }
}
