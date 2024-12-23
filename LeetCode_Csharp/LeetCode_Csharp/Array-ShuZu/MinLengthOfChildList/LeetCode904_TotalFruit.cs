using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.MinLengthOfChildList
{
    public class LeetCode904
    {
        // 904. 水果成篮
        //更新结果采用 向前搜索 的方式
        #region 采用向前搜索的方式更新窗口元素
        public int TotalFruit(int[] fruits)
        {
            int start = 0;
            int maxL = 0;
            List<int> fruit = new List<int>(3);
            for (int end = 0; end < fruits.Length; end++)
            {
                if (!fruit.Contains(fruits[end]))
                {
                    fruit.Add(fruits[end]);
                }

                while (fruit.Count > 2)
                {

                    start = end - 1;

                    fruit.Clear();
                    fruit.Add(fruits[end - 1]);
                    fruit.Add(fruits[end]);

                    // 查找窗口中的第一个不是fruits[end - 1]的元素
                    //向前搜索：无序，一个一个搜索
                    while (fruit.Contains(fruits[start]))
                    {
                        start--;
                    }
                    start++;
                }
                maxL = Math.Max(maxL, end - start + 1);

            }

            return maxL;
        }
        #endregion 采用向前搜索的方式更新窗口元素

        //因为更新的时候我们选择的是靠近最新元素的左边的元素：
        // 1 | 2 | 1 | 2 | 3 | 2 | 2
        //             ↑   ↑
        //          start end
        //所以我们使用 Dic 删除元素到最后判断那个减到 0 就除去对应键值对是没有问题的
        //因为最后 end 左边的元素在 Dic 中数量至少为 1
        #region 采用 Dictionary 删除 value 的方式更新窗口元素
        public int TotalFruit2(int[] fruits)
        {
            int start = 0;
            int maxL = 0;
            Dictionary<int, int> fruit = new Dictionary<int, int>(3);
            for (int end = 0; end < fruits.Length; end++)
            {
                if (!fruit.ContainsKey(fruits[end]))
                {
                    fruit.Add(fruits[end], 1);
                }
                else
                {
                    fruit[fruits[end]]++;
                }

                while (fruit.Count > 2)
                {
                    fruit[fruits[start]]--;
                    if (fruit[fruits[start]] == 0)
                    {
                        fruit.Remove(fruits[start]);
                    }
                    start++;
                }
                maxL = Math.Max(maxL, end - start + 1);

            }

            return maxL;
        }
        #endregion 采用 Dictionary 删除 value 的方式更新窗口元素
    }
}