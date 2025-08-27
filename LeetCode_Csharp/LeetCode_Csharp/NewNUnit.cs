using NUnit.Framework;
using Graph;

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
            int n = Console.Read(); int m = Console.Read();
            CountIsland.MyMain(n,m);
        }
    }
}


