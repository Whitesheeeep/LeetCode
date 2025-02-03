using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode15_ThreeSum_middle
    {   
        // 双指针法
        // 时间复杂度：O(n^2)
        // 空间复杂度：除结果外 O(1)
        public IList<IList<int>> ThreeSum(int[] nums)
        {
            //排序
            Array.Sort(nums);
            List<IList<int>> res = new();

            //O(N)
            for (int i = 0; i < nums.Length; i++)
            {
                // 当 nums[i] > 0 时，它与后续的数组不论如何都不能继续加成 0 （已排序）
                if(nums[i] > 0) return res;
                //对 i 进行去重
                if(i > 0 && nums[i] == nums[i-1]) continue;

                //准备指针
                int left = i + 1, right = nums.Length - 1;
                while(left < right)
                {
                    // 去重复逻辑如果放在这里，0，0，0 的情况，可能直接导致 right<=left 了，从而漏掉了 0,0,0 这种三元组
                    /*
                    while (right > left && nums[right] == nums[right - 1]) right--;
                    while (right > left && nums[left] == nums[left + 1]) left++;
                    */
                    int sum = nums[i] + nums[left] + nums[right];
                    if(sum > 0) right--;
                    else if(sum < 0) left++;
                    else
                    {
                        res.Add([nums[i], nums[left], nums[right]]);
                        //对 left 和 right 进行去重
                        while(left < right && nums[left] == nums[left + 1]) left++;
                        while(left < right && nums[right] == nums[right - 1]) right--;

                        //找到答案的时候，左右指针同时移动
                        left++;
                        right--;
                    }
                }
            }
            return res;
        }

        // 哈希表法
        // 时间复杂度：O(n^2)，空间复杂度：O(n)
        public IList<IList<int>> ThreeSum2(int[] nums)
        {
            //排序
            Array.Sort(nums);

            List<IList<int>> res = [];

            //nums[i] 为 a
            for(int i = 0; i < nums.Length; ++i)
            {
                if(nums[i] > 0) break;
                //对 a 进行去重
                if(i > 0 && nums[i] == nums[i-1]) continue;

                //哈希表存储 b
                HashSet<int> set = [];

                for(int j = i + 1; j < nums.Length; ++j)
                {
                    //对 c 进行去重，同时去重 b=c 时的结果
                    if(j > i+2 && nums[j] == nums[j-1] && nums[j] == nums[j-2]) continue;

                    int target = -nums[i] - nums[j];
                    if(set.Contains(target))
                    {
                        res.Add([nums[i], target, nums[j]]);
                        // 对 b 进行去重，不必担心 a 移动后的 b 重复，因为 a 移动后，b 会重新计算
                        // 而且必须去重，此时 a 是定的，b 如果不去重，那么 c 如果后续还有一样的值，会导致重复
                        // 比如： {-2,0,0,2,2}
                        set.Remove(target);
                    }
                    else
                    {
                        set.Add(nums[j]);
                    }
                }
            }

            return res;
        }
    }
}
