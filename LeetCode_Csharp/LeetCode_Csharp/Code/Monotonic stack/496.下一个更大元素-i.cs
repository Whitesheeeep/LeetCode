/*
 * @lc app=leetcode.cn id=496 lang=csharp
 *
 * [496] 下一个更大元素 I
 */

// @lc code=start
public partial class Solution {
    public int[] NextGreaterElement(int[] nums1, int[] nums2) {
        int[] res = new int[nums1.Length];
        for(int i = 0; i < res.Length; i++) res[i] = -1;

        Dictionary<int, int> nums1Dic = new();
        for (int i = 0; i < nums1.Length; i++)
        {
            nums1Dic.TryAdd(nums1[i], i);
        }

        Stack<int> monoStack = new();
        monoStack.Push(0);

        for (int i = 1; i < nums2.Length; i++)
        {
            if (nums2[i] <= nums2[monoStack.Peek()])
            {
                monoStack.Push(i);
            }
            else
            {
                while (monoStack.Count() > 0 && nums2[i] >nums2[ monoStack.Peek()])
                {
                    int index = monoStack.Pop();
                    if (nums1Dic.ContainsKey(nums2[index]))
                    {
                        res[nums1Dic[nums2[index]]] = nums2[i];
                    }

                }
                monoStack.Push(i);
            }
        }
        return res;
    }
}
// @lc code=end

