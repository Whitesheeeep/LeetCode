using LeetCode_Csharp.Code;
using LeetCode_Csharp.Code.DoublePointer;
using LeetCode_Csharp.Code.GreedyAlgorithm;

while(true)
{
    string input = Console.ReadLine();
    if (String.IsNullOrEmpty(input))
    {
        break;
    }

    Solution.LongestPalindromeSubseq(input);
}

