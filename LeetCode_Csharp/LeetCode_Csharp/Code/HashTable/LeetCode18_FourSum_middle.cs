using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.HashTable
{
    public class LeetCode18_FourSum_middle
    {
        #region 无剪枝四数之和
        //时间复杂度：O(N^3)
        public IList<IList<int>> FourSum(int[] nums, int target)
        {
            //排序
            Array.Sort(nums);
            List<IList<int>> res = new();

            int index = 0;
            while (index < nums.Length - 3)
            {
                List<IList<int>> threeSum = ThreeSum(nums[(index + 1)..], target - nums[index]);
                foreach (var item in threeSum)
                {
                    item.Add(nums[index]);
                    res.Add(item);
                }

                while (index < nums.Length - 3 && nums[index] == nums[index + 1])
                {
                    index++;
                }
                index++;
            }
            return res;
        }

        public List<IList<int>> ThreeSum(in int[] nums, int target)
        {
            List<IList<int>> res = new();

            //O(N)
            for (int i = 0; i < nums.Length; i++)
            {
                // 三数之和：当 nums[i] > 0 时，它与后续的数组不论如何都不能继续加成 0 （已排序）
                // 但是四数之和要注意：不是 0 的情况，不需要返回，因为不是 0 的情况，可能有后续的数组可以加成 target
                // 比如负数：-4 + -1 是可以达到更小的 -5 的。
                // if (nums[i] > target) return res;
                // 对 i 进行去重
                if (i > 0 && nums[i] == nums[i - 1]) continue;

                //准备指针
                int left = i + 1, right = nums.Length - 1;
                while (left < right)
                {
                    // 去重复逻辑如果放在这里，0，0，0 的情况，可能直接导致 right<=left 了，从而漏掉了 0,0,0 这种三元组
                    /*
                    while (right > left && nums[right] == nums[right - 1]) right--;
                    while (right > left && nums[left] == nums[left + 1]) left++;
                    */
                    long sum = (long)nums[i] + (long)nums[left] + (long)nums[right];
                    if (sum > target) right--;
                    else if (sum < target) left++;
                    else
                    {
                        res.Add([nums[i], nums[left], nums[right]]);
                        //对 left 和 right 进行去重
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        //找到答案的时候，左右指针同时移动
                        left++;
                        right--;
                    }
                }
            }
            return res;
        }
        #endregion 无剪枝四数之和

        #region 有剪枝四数之和
        //延续三数之和但是要注意细节。
        //时间复杂度：O(N^3)
        public IList<IList<int>> FourSum2(int[] nums, int target)
        {
            //排序
            Array.Sort(nums);
            List<IList<int>> res = [];

            for (int k = 0; k < nums.Length; k++)
            {
                // 剪枝：已经排序后，如果当前 nums[k] 大于 target，且大于 0，
                // 那么后续的数组不可能加成 target，因为后面的数肯定大于 nums[k]，
                // 怎么加都会大于 target
                if (nums[k] > target && nums[k] > 0) break;

                //去重
                if (k > 0 && nums[k] == nums[k - 1]) continue;
                for (int i = k + 1; i < nums.Length; i++)
                {
                    // 剪枝：已经排序后，如果当前 nums[i] + nums[k] 大于 target - nums[k]，且大于 0，
                    if (nums[i] + nums[k] > target && nums[i] + nums[k] > 0) break;
                    //if (nums[i] + nums[k] > target && nums[i] > 0) break; 也是一样的，后面那个判断加不加 nums[k] 不影响结果
                    // 去重
                    if (i > k + 1 && nums[i] == nums[i - 1]) continue;

                    int left = i + 1, right = nums.Length - 1;
                    while(left < right)
                    {
                        //防止数据溢出
                        long sum = (long)nums[k] + (long)nums[i] + (long)nums[left] + (long)nums[right];
                        if (sum > target) right--;
                        else if (sum < target) left++;
                        else
                        {
                            res.Add([nums[k], nums[i], nums[left], nums[right]]);
                            //对 left 和 right 进行去重
                            while (left < right && nums[left] == nums[left + 1]) left++;
                            while (left < right && nums[right] == nums[right - 1]) right--;

                            //找到答案的时候，左右指针同时移动
                            left++;
                            right--;
                        }
                    }
                }
            }

            return res;
        }
        #endregion 有剪枝四数之和
    }
}
