/*
 * @lc app=leetcode.cn id=84 lang=csharp
 *
 * [84] 柱状图中最大的矩形
 */

// @lc code=start
using Index = int;
public partial class Solution {
    public int LargestRectangleArea(int[] heights) {
        int[] newHeights = [0, .. heights, 0];

        Stack<Index> monoStack = new();
        monoStack.Push(0);

        int res = 0;

        for (int i = 1; i <  newHeights.Length; i++)
        {
            while (monoStack.Count > 0 && newHeights[i] < newHeights[monoStack.Peek()])
            {
                int index = monoStack.Pop();
                if (monoStack.Count() > 0)
                {
                    int h = newHeights[index];
                    int w = i - monoStack.Peek() - 1;
                    res = Math.Max(res, h * w);
                }
            }
            monoStack.Push(i);
        }
        return res;
    }
}
// @lc code=end

