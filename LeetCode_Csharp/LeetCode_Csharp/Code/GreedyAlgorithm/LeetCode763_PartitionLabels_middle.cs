namespace LeetCode_Csharp.Code.GreedyAlgorithm
{
    public class LeetCode763_PartitionLabels_middle
    {
        public IList<int> PartitionLabels(string s)
        {
            int[] hash = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                hash[s[i] - 'a'] = i;
            }

            List<int> result = [];
            int left = 0, right = 0;
            for(int i = 0 ; i < s.Length; i++)
            {
                right = Math.Max(hash[s[i] - 'a'], right);
                if(right == i)
                {
                    result.Add(right - left + 1);
                    left = i + 1;
                }
            }
            return result;
        }
    }
}
