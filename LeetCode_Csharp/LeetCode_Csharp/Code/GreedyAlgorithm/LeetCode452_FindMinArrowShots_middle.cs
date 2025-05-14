using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode452_FindMinArrowShots_middle
    {
        public int FindMinArrowShots(int[][] points)
        {
            if(points.Length == 1) return 1;
            // O(NlogN)
            Array.Sort(points, (num1,num2) => num1[0].CompareTo(num2[0]));

            int count= 1; // 需要的弓箭数
            int max = points[0][1];
            for(int i = 1; i < points.Length; i++)
            {
                int[] cur = points[i];
                // 有交集
                if(cur[0] <= max)
                {
                    max = Math.Min(cur[1], max);
                }
                else
                {
                    count++;
                    max = cur[1];
                }
            }

            return count;
        }
    }
}
