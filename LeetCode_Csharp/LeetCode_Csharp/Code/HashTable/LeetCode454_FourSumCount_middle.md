# LeetCode454_FourSumCount 四数相加II_middle

> [LeetCode454 四数相加II](https://leetcode.cn/problems/4sum-ii/description/)

如果暴力对四组进行轮询，则时间复杂度为 O$(n^4)$，因此肯定必须有其他方式进行搜索。

那么此题思想就是：如同 LeetCode454 TwoSum 一样，我们可以先采用一个数组得到一个 Dict，然后对其他几个数组采用 target - ... 进行查找 dict 是否有对应的数字。

那么最好的就是 两两相加，进行分组，先对 num1 + num2 的结果装入一个 dict 中，然后 轮询 num3 + num4，查询 dict 中是否有 0-num3-nums4 （因为 num1 + num2 + num3 + num4 = 0），这样时间复杂度就可以压缩为 O$(2n^2)$。

>为什么不是 1 3 拆分：这样对于那个 3 就需要 3 遍轮询，时间复杂度为 O$(N^3)$。通常都是对半分。
