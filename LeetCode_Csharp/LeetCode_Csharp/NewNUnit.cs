using NUnit.Framework;
using LeetCode_Csharp.Code.GreedyAlgorithm;

namespace LeetCode_Csharp
{
    public class NewNUnit
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public void Test1()
        {
            LeetCode56_Merge_middle test = new();
            int[][] testArray = [[1,4],[0,4]];
            var res = test.Merge(testArray);
            Assert.AreEqual(res, new int[][]{[0,4]});
        }
    }
}


