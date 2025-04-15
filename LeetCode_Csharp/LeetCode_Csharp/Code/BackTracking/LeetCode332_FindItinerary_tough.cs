using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode332_FindItinerary_tough
    {
        List<string> path;
        List<IList<string>> res;
        bool[] used;
        public IList<string> FindItinerary(IList<IList<string>> tickets)
        {
            path = ["JFK"];
            res = new();
            used = new bool[tickets.Count];
            BackTracking(tickets);
            // 对 res 中元素进行比较，找出最小的元素
            return FindMinPath(res);
        }

        private IList<string> FindMinPath(List<IList<string>> res)
        {
            if(res.Count <= 1) return res[0];
            int slow = 0;
            for(int fast = 1; fast < res.Count; fast++)
            {
                if(!CompareStringList(res[slow],res[fast])) // slow 大
                {
                    System.Console.WriteLine(CompareStringList(res[slow], res[fast]));
                    slow = fast;
                    System.Console.WriteLine(slow);
                }
            }
            return res[slow];
        }
        
        // 如果 list1 > list2 则返回 false
        public bool CompareStringList(IList<string> list1, IList<string> list2)
        {

            for(int i = 0; i < list1.Count; i++)
            {
                if(!CompareString(list1[i],list2[i])) return false;
            }
            return true;
        }

        private void BackTracking(IList<IList<string>> tickets)
        {
            if (path.Count == tickets.Count + 1)
            {
                res.Add([..path]);
                return;
            }
            
            // ! 错误点：前面的那一个可能是没有结果的但是大小是比后者小的
            for (int i = 0; i < tickets.Count; i++)
            {
                if (path.Count <= 1 && tickets[i][0] != "JFK") continue; // 保证第一张票由 JFK 开始
                if (used[i] == true) continue; // 如果票已经用过，跳过
                if (path.Last() != tickets[i][0]) continue; // 如果票对不上，就跳过


                path.Add(tickets[i][1]);
                used[i] = true;
                BackTracking(tickets);
                used[i] = false;
                path.RemoveAt(path.Count - 1);
            }
        }

        /// <summary>
        /// first 的字符串大于 second 返回false 反之 true
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private bool CompareString(string first, string second)
        {
            for(int i = 0; i < 3; i++)
            {
                if(first[i] > second[i]) return false;
                if(first[i] < second[j]) return true;
            }
            return true;
        }

        /* private List<string> MinPath()
        {

        } */
    }
}
