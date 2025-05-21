using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode56_Merge_middle
    {
        public int[][] Merge(int[][] intervals)
        {
            if(intervals.Length <= 1) return intervals;

            Array.Sort(intervals, (num1, num2) => {
                if(num1[0] == num2[0]) return num1[1].CompareTo(num2[1]);
                else return num1[0].CompareTo(num2[0]);
            });

            int left = intervals[0][0], right = intervals[0][1];
            List<int[]> res = [];
            for(int i = 1; i < intervals.Length; i++)
            {
                if(intervals[i][0] <= right) // 重叠了
                {
                    right = Math.Max(intervals[i][1], right);
                }
                else // 没重叠
                {
                    res.Add([left, right]);
                    left = intervals[i][0];
                    right = intervals[i][1];
                }
            }
            res.Add([left, right]);
            return res.ToArray();
        }
    }
}
