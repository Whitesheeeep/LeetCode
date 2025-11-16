List<int> nums = new();

// 统计频率
Dictionary<int, int> countMap = new();
foreach (int num in nums)
{
    if (countMap.ContainsKey(num))
        countMap[num]++;
    else
        countMap[num] = 1;
}

PriorityQueue<int, int> priorityQueue = new();

