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
