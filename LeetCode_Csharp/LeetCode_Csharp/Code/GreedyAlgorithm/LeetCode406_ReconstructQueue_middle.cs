using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode406_ReconstructQueue_middle
    {
        public int[][] ReconstructQueue(int[][] people)
        {
            if(people.Length <= 1) return people;

            // O(nlogn)
            Array.Sort(people, (num1,num2) => 
            {
                if(num1[0] == num2[0])
                    return num1[1].CompareTo(num2[1]);
                return -num1[0].CompareTo(num2[0]);
            });
            
            List<int[]> queue = [];
            for(int i = 0 ; i < people.Length; i++)
            {
                queue.Insert(people[i][1], people[i]);
            }
             

            return queue.ToArray();

        }
    }
}
