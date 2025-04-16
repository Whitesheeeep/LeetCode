using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.BackTracking
{
    public class LeetCode51_SolveNQueens_tough
    {
        // 记录结果的方式为对每一行记录对应的索引作为结果，比如第一行的皇后位于第一个位置，记录索引 0 作为第一个皇后的位置
        List<int> path;
        List<IList<int>> res;
        List<(int x,int y)> used;
        public IList<IList<string>> SolveNQueens(int n)
        {
            // 初始化
            res = [];
            path = [];
            used = new();
            return null;
        }


        // 进行 n 轮，记录能够防止皇后的位置索引
        // path 进行回溯，path 长度达到对应的长度后加入到结果
        /// <summary>
        /// 
        /// </summary>
        /// <param name="n">n 为棋盘边长</param>
        private void BackTracking(int n, int x)
        {
            if(path.Count == n)
            {
                res.Add([..path]);
                return;
            }

            // ? 如果判断这个位置已经被占住，横向已经通过迭代控制，竖向可以根据path，斜方向处理方式？: x+n,y+n 
            // 竖向处理：定义一个 usedX
            // ? 如何知道 y? 定义一个参数用于确定 y。
            for(int index = 0; index < n; index++)
            {
                // if(used[index] == 1) continue;
                // 判断斜方向的
                // if() continue;

                used.Add((x,index));
                path.Add(index);
                
                BackTracking(n, x+1);
                used.Remove((x,index));
                path.RemoveAt(path.Count - 1);
            }
        }
    }
}
