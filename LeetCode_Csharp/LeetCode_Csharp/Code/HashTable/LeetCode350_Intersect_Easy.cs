using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode350_Intersect_Easy
    {
        //采用 Dictionary 进行解决
        //时间复杂度：O(n+m)
        public int[] Intersect(int[] nums1, int[] nums2)
        {
            Dictionary<int, int> dict1 = [];
            Dictionary<int, int> dict2 = [];
            foreach (int num in nums1)
            {
                if (dict1.ContainsKey(num))
                {
                    dict1[num]++;
                }
                else
                {
                    dict1[num] = 1;
                }
            }
            foreach (int num in nums2)
            {
                if (dict2.ContainsKey(num))
                {
                    dict2[num]++;
                }
                else
                {
                    dict2[num] = 1;
                }
            }
            List<int> res = new();
            foreach (int key in dict1.Keys)
            {
                if (dict2.ContainsKey(key))
                {
                    int count = Math.Min(dict1[key], dict2[key]);
                    for (int i = 0; i < count; i++)
                    {
                        res.Add(key);
                    }
                }
            }
            return res.ToArray();
        }
    
        //如果是已经排序号的就用双指针
        public int[] Intersect2(int[] nums1, int[] nums2)
        {
            Array.Sort(nums1);
            Array.Sort(nums2);
            int i = 0, j = 0;
            List<int> res = new();
            while (i < nums1.Length && j < nums2.Length)
            {
                if (nums1[i] == nums2[j])
                {
                    res.Add(nums1[i]);
                    i++;
                    j++;
                }
                else if (nums1[i] < nums2[j])
                {
                    i++;
                }
                else
                {
                    j++;
                }
            }
            return res.ToArray();
        }
    
        //如果 nums2 的元素个数远远小于 nums1 的元素个数，那么可以采用这种方式
        public int[] Intersect3(int[] nums1, int[] nums2)
        {
            // 同样适用于 nums1 的元素个数远远小于 nums2 的元素个数，这其实就是普通情况
            // if (nums1.Length < nums2.Length)
            // {
            //     return Intersect3(nums2, nums1);
            // }

            Dictionary<int, int> dict = [];
            foreach (int num in nums1)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num]++;
                }
                else
                {
                    dict[num] = 1;
                }
            }
            List<int> res = new();
            foreach (int num in nums2)
            {
                if (dict.ContainsKey(num) && dict[num] > 0)
                {
                    res.Add(num);
                    dict[num]--;
                    if(dict[num] == 0)
                    {
                        dict.Remove(num);
                    }
                }
            }
            return res.ToArray();
        }

        //如果 nums2 的元素存储在磁盘上，内存有限，不能一次加载到内存中
        
    }
}
