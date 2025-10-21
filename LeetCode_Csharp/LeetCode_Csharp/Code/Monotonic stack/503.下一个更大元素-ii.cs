/*
 * @lc app=leetcode.cn id=503 lang=csharp
 *
 * [503] 下一个更大元素 II
 */

// @lc code=start
public partial class Solution {
    public int[] NextGreaterElements(int[] nums) {

        int[] dualNums = [.. nums, .. nums];

        int[] res = new int[nums.Length * 2];
        for (int i = 0; i < res.Length; i++) res[i] = -1;

        Stack<int> monoStack = new();
        monoStack.Push(0);

        for (int i = 1; i < dualNums.Length; i++)
        {
            if (dualNums[i] <= dualNums[monoStack.Peek()])
            {
                monoStack.Push(i);
            }
            else
            {
                while (monoStack.Count() > 0 && dualNums[i] > dualNums[monoStack.Peek()])
                {
                    int index = monoStack.Pop();
                    res[index] = dualNums[i];
                }
                monoStack.Push(i);
            }
        }
        return res[..nums.Length];
    }
}
// @lc code=end

