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
                return num1[0].CompareTo(num2[0]);
            });
            
            // O(n)
            int[][] queue = new int[people.Length][];
            // for(int i = 0; i < queue.Length; i++) queue[i] = new int[2];
            
            // O(n^2)
            for(int i = 0; i < people.Length; i++)
            {
                
                int index  = people[i][1];
                if(queue[index] == null) queue[index] = people[i];
                else
                {
                    index++;
                    while(queue[index] != null) index++;
                    queue[index] = people[i];
                }
            }
            return queue;

        }
    }
}
