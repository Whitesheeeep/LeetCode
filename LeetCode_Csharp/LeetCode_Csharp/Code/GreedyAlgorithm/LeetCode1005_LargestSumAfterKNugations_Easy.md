# LeetCode1005_LargestSumAfterKNugations_Easy

> [LeetCode1005 k次取反后最大化的数组和](https://leetcode.cn/problems/maximize-sum-of-array-after-k-negations/description/)

- [LeetCode1005\_LargestSumAfterKNugations\_Easy](#leetcode1005_largestsumafterknugations_easy)
  - [思路](#思路)

## 思路

主要讲解贪心的思路，本体涉及两次贪心：
第一次贪心发生在我们 k 次取反想要得到最大sum，那么就应该对负数的最大值进行取反。
第二次贪心：局部最优：只找数值最小的正整数进行反转，当前数值和可以达到最大值。全局最优：整个数组和达到最大。
