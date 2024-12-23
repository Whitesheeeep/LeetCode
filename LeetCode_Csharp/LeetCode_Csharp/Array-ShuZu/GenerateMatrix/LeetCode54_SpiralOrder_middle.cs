using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.GenerateMatrix
{
    public class LeetCode54_SpiralOrder_middle
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            //一个 m * n 的矩阵，m 行 n 列
            int m = matrix.Length;
            int n = matrix[0].Length;

            int[] res = new int[m * n];

            int loop = Math.Min(m, n) / 2;
            int num = 0;
            int startx = 0, starty = 0;
            while (loop > 0)
            {
                int i = startx, j = starty;
                //矩阵顶层，从左到右
                for (; j < n - starty - 1; j++)
                {
                    res[num++] = matrix[startx][j];
                }
                //矩阵右层，从上到下
                for (; i < m - startx - 1; i++)
                {
                    res[num++] = matrix[i][j];
                }
                //矩阵底层，从右到左
                for (; j > starty; j--)
                {
                    res[num++] = matrix[i][j];
                }
                //矩阵左层，从下到上
                for (; i > startx; i--)
                {
                    res[num++] = matrix[i][j];
                }
                loop--;
                (startx, starty) = (startx + 1, starty + 1);
            }

            //如果是方阵
            if (m == n && m % 2 == 1) res[num] = matrix[m / 2][n / 2];
            else if (n > m && m % 2 == 1)
            {
                for (int j = starty; j < starty + n - m + 1; j++)
                {
                    res[num++] = matrix[startx][j];
                }
            }
            else if (m > n && n % 2 == 1)
            {
                for (int i = startx; i < startx + m - n + 1; i++)
                {
                    res[num++] = matrix[i][starty];
                }
            }

            return res;

        }

        //另一种思路
        public IList<int> SpiralOrder2(int[][] matrix)
        {
            if (matrix.Length == 0) return new List<int>();

            //一个 m * n 的矩阵，m 行 n 列
            int m = matrix.Length, n = matrix[0].Length;
            int[] res = new int[m * n];

            //初始化
            int left = 0, right = n - 1, top = 0, bottom = m - 1;
            int num = 0;
            while(true)
            {
                //从左到右
                for (int i = left; i <= right; i++)
                {
                    res[num++] = matrix[top][i];
                }

                if (++top > bottom) break;
                //从上到下
                for (int i = top; i <= bottom; i++)
                {
                    res[num++] = matrix[i][right];
                }

                if (--right < left) break;
                //从右到左
                for (int i = right; i >= left; i--)
                {
                    res[num++] = matrix[bottom][i];
                }

                if (--bottom < top) break;
                //从下到上
                for (int i = bottom; i >= top; i--)
                {
                    res[num++] = matrix[i][left];
                }

                if (++left > right) break;
            }

            return res;
            
        }
    }
}
