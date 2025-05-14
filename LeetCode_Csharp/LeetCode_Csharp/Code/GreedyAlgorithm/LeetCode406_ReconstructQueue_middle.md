# LeetCode406_ReconstructQueue_middle

> [LeetCode406 根据身高重建队列](https://leetcode.cn/problems/queue-reconstruction-by-height/description/)

## 思路

1. 首先，之前做过糖果分发，里面思路提到过：如果涉及到两个维度的思考的时候，**最好先处理一个维度，再去处理另一个维度**。本体也是涉及到两个维度：身高 h 和 前面有多少人身高 >= 本人身高 k。因此我们需要确定其中一个维度，然后再处理另一个维度。
2. 那么**是确定 h 还是 k，又应该是按增序还是降序排列**。这都是需要思考的。阅读本体其实也给了一定线索，题目要求：k 表明前面有多少人身高 >= 本人身高，因此降序排列身高是最好的。因为数组中所有的元素前面都是高于本元素身高的，这样就解决了一个维度。之后就只需要单处理 k 即可，h 因素被解决了。
3. **处理 k**：
k 表示前面有多少人 h >= 本人 h。经过前面的处理，可以知道前面所有的人的 h 都 >= 本人 h，因此我们只需要将本人安排到前面的第 k 个索引位置即可，这样索引 0 ~ k-1 共 k 个人的身高 >= 本人身高，符合题意。

### 思路细节

1. **身高相同的，k 不同的如何处理。**
还是注意：k 表示前面有多少人 h >= 本人 h。那么如果我们在排序的时候让 k 大的排后面，就会自动在排序的时候处理排好了一部分人。

2. **确定 h 先处理。**
如果先处理 k 的话，即有限按照 k 小的排序，此时 k 这个维度并没有解决 k 这个维度，因为 k 小的没法判断后续的 h 是否能达到制定 k 的位置。按照 h 从大到小排序能保证前面的身高 $h_前$ 肯定 >= 后续的身高 $h_后$，从而解决 h 这个维度。
如果按照 h 从小到大排序，也不是不行，但是处理更加复杂，没有 h 从大到小排方便。

3. **为什么直接插入到索引为 k 的地方就行了？**
还是因为 k 表示前面有多少人 h >= 本人 h。而我们排序后从前往后遍历，就是从大往小遍历，我们将元素插入到 索引为 k 的位置，前面 k 个数肯定大于本元素，是满足题意的，这也就是局部最优，那么就可以推出全局最优，找不出反例。

以上便是本体的主要思路。

## 代码

```CSharp
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
```

### 优化

上述代码主要问题在于使用 List 进行插入会导致扩容的问题，而扩容会消耗性能，而链表插入很快捷，而且本体不会用到查询，因此可以采取使用链表的方式来避免扩容。
C# 中即可以用 LinkedList<int[]> 代替，C++ 则是用 List<vector\<int>> 代替 vector<vector\<int>>。
