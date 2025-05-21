public class LeetCode435_EraseOverlapIntervals_middle
{
    public int EraseOverlapIntervals(int[][] intervals)
    {
        if (intervals.Length <= 1) return 0;

        Array.Sort(intervals, (item1, item2) =>
        {
            if (item1[0] == item2[0])
                return item1[1].CompareTo(item2[1]);
            return item1[0].CompareTo(item2[0]);
        });

        int count = 0;
        int /* left = intervals[0][0],  */ right = intervals[0][1];

        // 贪心，让每次删减的区间都是最大的
        for (int i = 1; i < intervals.Length; i++)
        {
            if (intervals[i][0] < right) // 相交
            {
                count++;
                right = Math.Min(intervals[i][1], right);
            }
            else right = intervals[i][1];
        }

        return count;
    }
}
