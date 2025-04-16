using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode332_FindItinerary_tough
    {
        LinkedList<string> path;
        List<string> res;
        bool[] used;

        #region 超时方法
        public IList<string> FindItineraryButOverTime(IList<IList<string>> tickets)
        {
            path = new();
            path.AddLast("JFK");
            System.Console.WriteLine(path.Count);
            // res = new();
            used = new bool[tickets.Count];
            
            IList<string>[] ticketsArray = [..tickets];
            Array.Sort(ticketsArray , (first, second) =>
            {
                return first[1].CompareTo(second[1]);
            });
            // tickets = [.. strings];
            BackTracking(ticketsArray);
            // 对 res 中元素进行比较，找出最小的元素
            return res;
        }
        private bool BackTracking(IList<string>[] tickets)
        {
            if (path.Count == tickets.Length + 1)
            {
                res = [.. path];
                return true;
            }

            // ! 错误点：前面的那一个可能是没有结果的但是大小是比后者小的
            for (int i = 0; i < tickets.Length; i++)
            {
                // if (path.Count <= 1 && tickets[i][0] != "JFK") continue; // 保证第一张票由 JFK 开始
                if (used[i] == true) continue; // 如果票已经用过，跳过
                System.Console.WriteLine(path.Count);
                if (path.Last() != tickets[i][0]) continue; // 如果票对不上，就跳过
                if(i > 0 && tickets[i-1] == tickets[i] && used[i-1] == false) continue;


                path.AddLast(tickets[i][0]);
                used[i] = true;
                if (BackTracking(tickets)) return true;
                used[i] = false;
                path.RemoveLast();
            }
            return false;
        }
        #endregion

        private IList<string> FindMinPath(List<IList<string>> res)
        {
            if (res.Count <= 1) return res[0];
            int slow = 0;
            for (int fast = 1; fast < res.Count; fast++)
            {
                if (!CompareStringList(res[slow], res[fast])) // slow 大
                {

                    slow = fast;

                }
            }
            return res[slow];
        }

        // 如果 list1 > list2 则返回 false
        public bool CompareStringList(IList<string> list1, IList<string> list2)
        {

            for (int i = 0; i < list1.Count; i++)
            {
                bool temp = CompareString(list1[i], list2[i]);
                if (!temp) return false;
                if (temp) return true;
            }
            return true;
        }


        /// <summary>
        /// first 的字符串大于 second 返回false 反之 true
        /// </summary>
        /// <param name="first"></param>
        /// <param name="second"></param>
        /// <returns></returns>
        private bool CompareString(string first, string second)
        {
            for (int i = 0; i < 3; i++)
            {
                if (first[i] > second[i]) return false;
                if (first[i] < second[i]) return true;
            }
            return true;
        }

        /* private List<string> MinPath()
        {

        } */
    }
}
