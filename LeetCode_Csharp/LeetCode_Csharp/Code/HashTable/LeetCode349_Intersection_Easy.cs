using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode349_Intersection_Easy
    {
        //采用 set 进行解决
        public int[] Intersection(int[] nums1, int[] nums2)
        {
            HashSet<int> result = new();
            HashSet<int> set1 = [..nums1];
            foreach(int num in nums2)
            {
                if(set1.Contains(num))
                {
                    result.Add(num);
                    // //存在一次就删除一次，避免重复(使用 List<int> 存储结果时使用)
                    // set1.Remove(num);
                }
            }
            
            return result.ToArray();
        }


    }
}
