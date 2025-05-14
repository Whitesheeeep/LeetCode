# LeetCode135_Candy_tough

> [LeetCode135 分发糖果](https://leetcode.cn/problems/candy/description/)

## 思路

这道题目的主要难点就是在于如果判断 index = i 此处左右两边哪一边比 i 小的长度长，然后以那一边的最低点为 1 进行累加 1 就可以得到最佳的 index = i 出的糖果数。另一边直接从最小逐渐往 index = i（但是 index = i 处不加入）进行递增 +1 即可。
**对于这种需要对两个维度进行考虑的问题，一定要先确定一个维度，然后再确定另一个维度。**

---

**问题：** 如何判断哪一边的连续少于的更多。
**解决方法：** 先从左到右的遍历一遍，对 ratings[i] > ratings[i - 1] 的在左边获得糖果的基础上加 1。
然后从右往左遍历一遍，同样如上，但是此时因为会有第一次遍历的糖果，因此我们需要比较一下糖果的数量并选择糖果数量多的并赋值。
综上，这样我们就在 O(n) 时间复杂度的情况下解决了上述问题。
> 上述思维可以拓展到需要左右判断一定条件的处理的题目，使用上述思路也是有利于解题的。

## 贪心

那么本题我采用了两次贪心的策略：

- 一次是从左到右遍历，只比较右边孩子评分比左边大的情况。
- 一次是从右到左遍历，只比较左边孩子评分比右边大的情况。

这样从局部最优推出了全局最优，即：相邻的孩子中，评分高的孩子获得更多的糖果。

## 代码

```CSharp
namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode135_Candy_tough
    {
        public int Candy(int[] ratings)
        {
            int[] res = new int[ratings.Length];
            res[0] = 1;
            for(int i = 1; i < ratings.Length; i++)
            {
                res[i] = 1;
                if(ratings[i] > ratings[i-1]) res[i] += res[i-1];
            }

            for(int i = ratings.Length - 2; i >= 0; i--)
            {
                if(ratings[i] > ratings[i+1]) res[i] = Math.Max(res[i+1]+1, res[i]);
            }

            int resSum = 0;
            foreach(int i in res)
                resSum += i;
            return resSum;
        }
    }
}
```
