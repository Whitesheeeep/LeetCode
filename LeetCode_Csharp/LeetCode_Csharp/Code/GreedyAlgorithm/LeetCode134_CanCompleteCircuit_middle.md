# LeetCode134_CanCompleteCircuit_middle

> [LeetCode134 加油站](https://leetcode.cn/problems/gas-station/description/)

- [LeetCode134\_CanCompleteCircuit\_middle](#leetcode134_cancompletecircuit_middle)
  - [思路 1](#思路-1)
    - [核心思路](#核心思路)
      - [After 和 Front 的记录](#after-和-front-的记录)
    - [代码](#代码)
  - [思路 2](#思路-2)
    - [核心思路 2](#核心思路-2)
    - [代码 2](#代码-2)

## 思路 1

时间复杂度为 O(n)。空间复杂度：O(1)。
我们要判断是否能够到达是否能够绕一圈行驶，使用 O(n) 时间复杂度我们一轮轮询进行处理。

### 核心思路

如下图所示，我们就记录 Front 和 After 的累计 gas[i] - cost[i]（After 要记录自身，即 i ），通过记录这两个，我们可以通过判断 After 是否能够满足 Front，即可判断 i 是否能够跑一圈。
![alt text](Img/LC134_1.png)

#### After 和 Front 的记录

**Front 记录：**
Front 只需要记录最大的累计耗补差即可。首先，Front 记录的是从 0 到 i 的累计耗补差，那么最后可能会是：[-2，-2，-2，3，3]，我们不能直接统计累计耗补差，这样如上数组所示，累计耗补差为 0，但是其实从最后一站到 0 到 3这个站需要 6 个油，但是这个存储的是累计耗油比，这样肯定是不可能达到 3 站，因此我们需要存储的不是绝对的累计耗补差。
那么我们需要存储的是应该是最小的累计油耗差（因为是负值，所以记录最小）。原因如下：如果从 0 -> s -> i-1，0 到 i-1 需要的最小累计油耗差为 gasMax[i-1]，而 0 到 s 需要的更少，所以肯定能到 s，**运用数学归纳法就可以推出来**到 i-1，因此存储最小的累计油耗差。
**After 的记录：**
因为采用的是一轮for，因此我们随着 for 循环记录即可。遇到 gas[i] - cost[i] >= 0，我们就开始用一个 int 记录累计油耗差，用 index 记录开始车站：

- 如果累计油耗差 < 0，就抛弃这个 index，并且不需要从 index + 1，进行，直接顺着 for 进行。原因如下：
因为 i 处 gas[i] - cost[i] >= 0，如果中间存在一个位置 m 能够绕一周的，那说明能够从 i 到 m，那这样就说明了可以从 i 到 m，而 m 可以绕一周，那么 i 应该也可以绕一周，这就与条件相悖，说明中间不存在这样的位置，因此，我们就不用往回溯，直接顺着for 循环继续即可。

### 代码

```C#
namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode134_CanCompleteCircuit_middle
    {
        public int CanCompleteCircuit(int[] gas, int[] cost)
        {
            if(gas.Length == 1) return gas[0] - cost[0] >= 0 ? 0 : -1;

            int gasMax = int.MaxValue, gasMaxIndex = 0;
            int gasCostSubFromZero = 0;
            int gasCostSubFromValid = 0;
            int index = 0;
            bool startSum = false;
            for (int i = 0; i < gas.Length; i++)
            {
                if(i > 0) gasCostSubFromZero += gas[i - 1] - cost[i - 1];
                gasMax = gasCostSubFromZero < gasMax ? gasCostSubFromZero : gasMax;
                // 收集从 0 开始到 i 站所缺少的油量
                // 用于判断从数组的末尾站到初始站需要至少需要多少油量才能到达首站

                int gasCost = gas[i] - cost[i];
                if(gasCost >= 0 && startSum == false)
                {
                    gasMaxIndex = gasMax;
                    startSum = true;
                    index = i;
                }

                if(startSum == true)
                {
                    gasCostSubFromValid += gasCost;
                    if(gasCostSubFromValid < 0)
                    {
                        startSum = false;
                        gasCostSubFromValid = 0;
                    }
                    if(i == gas.Length - 1 && gasCostSubFromValid >= -gasMaxIndex)
                        return index;
                }
                
                
            }

            return -1;
        }
    }
}
```

## 思路 2

其实这个思路和上面的思路一中的 Front 记录 + 累计油耗差 < 0 思路差不多。也是计算累计油耗差（gas[i] - cost[i]），如果需要知道以下两个点：

1. 如果总油量 gasSum 减去总消耗 costSum ，即restSum，大于等于零，那么一定可以跑完一圈，也就是肯定存在一个位置能够跑一圈。

> **证充分：** restSum >= 0 => 肯定能跑一圈:
假设这个能够跑一圈的位置为 x，0 跑到 x 的累计油耗差为 restSum_0x < 0，x 跑到最后一站的累计油耗差为 restSum_xl >= 0。
则 restSum = restSum_0x + restSum_xl >= 0
=> restSum_0x >= -restSum_xl
=> 能够跑一圈
**证必要：** 能跑一圈 => restSum >= 0：
即证 restSum < 0 => 不能跑一圈
反证法：假设 restSum < 0 => 能跑一圈
假设起始位置为 x，依旧是利用证充分两个假设参数。二者至少存在一个 < 0，说明必然有一侧不能达到另一侧，只要有一侧无法达到另一侧， 也就无法跑一圈，与假设相悖，证毕。
综上，最初的论断结论成立。

2. 从位置 a 开始，到 i 的累计油耗差 restSum_ai < 0 时，a 到 i 中不存在能够到 i 的加油站位置。

> 其实证第一个结论必要性的时候已经证明了。

### 核心思路 2

那么我们就可以从头开始遍历，记录从 start 位置开始的 累计油耗差 curSum，以及从 0 开始的总累计油耗差 totalSum。

- 如果 curSum < 0，说明无法从 start 到 i，此时从 i + 1 位置开始从新累计。
- 如果 totalSum < 0，说明不存在能跑一圈的位置。

### 代码 2

```CSharp
// 贪心算法，方法二
public class Solution
{
    public int CanCompleteCircuit(int[] gas, int[] cost)
    {
        int curSum = 0, totalSum = 0, start = 0;
        for (int i = 0; i < gas.Length; i++)
        {
            curSum += gas[i] - cost[i];
            totalSum += gas[i] - cost[i];
            if (curSum < 0)
            {
                start = i + 1;
                curSum = 0;
            }
        }
        if (totalSum < 0) return -1;
        return start;
    }
}
```
