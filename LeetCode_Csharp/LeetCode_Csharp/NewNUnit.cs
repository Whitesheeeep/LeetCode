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
            LeetCode452_FindMinArrowShots_middle test = new();
            int[][] test_1 = [[1,2],[3,4]],
            test_2 = [[1,2]],
            test_3 = [[1,2], [2,3], [3,4]],
            test_4 = [[1,10], [-1,2], [0,1], [2,4]];
            
            int res_1 = test.FindMinArrowShots(test_1);
            int res_2 = test.FindMinArrowShots(test_2);
            int res_3 = test.FindMinArrowShots(test_3);
            int res_4 = test.FindMinArrowShots(test_4);
            
            Assert.AreEqual(res_1, 2); 
            Assert.AreEqual(res_2, 1);
            Assert.AreEqual(res_3, 2);
            Assert.AreEqual(res_4, 2);
        }
    }
}


