# LeetCode51_SolveNQueens_tough

> [LeetCode51](https://leetcode.cn/problems/n-queens/description/)

## 难点

1. 如何处理二维数组的回溯
2. 如何判断一行一列以及两对角（右斜对角，左斜对角）是否存在皇后

## 解决

1. 处理回溯其实很简单，我在写代码的时就发现回溯其实很契合这个题目。其实每次 BackTracking 就是往下一行 row，for 循环就是下一个 column，因此这个问题就轻松解决了。

2. 解决第二个问题的方法，行和列的处理方式很简单，甚至可以说是自然而然就解决了。我们在每次递归的时候传入 row 的时候 +1，就避免了同行；在每次 for 的过程中就避免了同列；因此我们首要解决的问题其实是左右斜对角的问题：如何判断左右斜对角是否存在皇后。

## 判断斜对角是否存在皇后

其实可以直接暴力轮询，我们每次都传入 row 和 column，然后通过 for 循环往上面的每一行进行判断对角是否存在皇后。
**但是：**
我们对棋盘进行处理，用 row - column 以及用 row + column 进行处理，得到棋盘上各位置的结果如下（以 n = 4 举例）：

|Sub|0|1|2|3|
|:--:|-|-|-|-|
|0|0|1|2|3|
|1|-1|0|1|2|
|2|-2|-1|0|1|
|3|-3|-2|-1|0|

|Add|0|1|2|3|
|:--:|-|-|-|-|
|0|0|1|2|3|
|1|1|2|3|4|
|2|2|3|4|5|
|3|3|4|5|6|

如上所示，我们可以发现，row - column 的 Sub 这个表格中的正斜对角线的表格中的值是一样的，在 row + column 的 Add 这个表格中的逆斜对角线的表格中的值是一样的，因此我们可以根据这个特性进行判断对应的斜对角线是否存在皇后。

## 代码

如下所示，我们通过哈希表装载对应的斜对角的加减成员，直接每次使用皇后的时候判断是否在这两个 set 中存在即可判断两个对角是否存在皇后了。

```C#
using System.Text;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode51_SolveNQueens_tough
    {
        // 记录结果的方式为对每一行记录对应的索引作为结果，比如第一行的皇后位于第一个位置，记录索引 0 作为第一个皇后的位置
        List<int> path;
        List<IList<string>> res;
        HashSet<int> usedOppoAngleRight;
        HashSet<int> usedOppoAngleLeft;
        bool[] usedX;
        public IList<IList<string>> SolveNQueens(int n)
        {
            // 初始化
            res = [];
            path = [];
            usedOppoAngleRight = new();
            usedOppoAngleLeft = new();
            usedX = new bool[n];
            BackTracking(n,0);
            // 组成最后的结果
            return res;
        }


        // 进行 n 轮，记录能够防止皇后的位置索引
        // path 进行回溯，path 长度达到对应的长度后加入到结果
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">n 为棋盘边长</param>
        private void BackTracking(int n, int y)
        {
            if(path.Count == n)
            {
                List<string> pathStr = BuildString(n, path);
                res.Add([..pathStr]);
                return;
            }

            // ? 如果判断这个位置已经被占住，横向已经通过迭代控制，竖向可以根据path，斜方向处理方式？: x+n,y+n 
            // 竖向处理：定义一个 usedX
            // ? 如何知道 y? 定义一个参数用于确定 y。
            for(int index = 0; index < n; index++)
            {
                if(usedX[index] == true) continue;
                // 判断斜方向的
                if(usedOppoAngleRight.Contains(y - index) || usedOppoAngleLeft.Contains(index + y)) continue;

                usedOppoAngleRight.Add(y - index);
                usedOppoAngleLeft.Add(y + index);

                path.Add(index);
                usedX[index] = true;
                
                BackTracking(n, y+1);
                usedOppoAngleRight.Remove(y-index);
                usedOppoAngleLeft.Remove(y + index);

                path.RemoveAt(path.Count - 1);
                usedX[index] = false;
            }
        }

        private List<string> BuildString(int n, List<int> path)
        {
            List<string> res = new();
            foreach(int index in path)
            {
                StringBuilder sb = new();
                for(int i = 0; i < index; i++)
                    sb.Append('.');
                sb.Append('Q');
                for(int i = index + 1; i < n; i++)
                    sb.Append('.');
                res.Add(sb.ToString());
            }
            return res;
        }
    }
}
```
