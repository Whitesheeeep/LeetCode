using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.GenerateMatrix
{
    public class LeetCode59_GenerateMatrix_middle
    {
        public int[][] GenerateMatrix(int n)
        {
            int[][] res = {
                new int[n],
                new int[n],
                new int[n]
            };
            int startx = 0, starty = 0;
            int loop = n / 2;
            int num = 1;

            while (loop > 0)
            {
                int i = startx, j = starty;
                //矩阵顶层，从左到右
                for (; j < n - starty - 1; j++)
                {
                    res[startx][j] = num++;
                }
                //矩阵右层，从上到下
                for (; i < n - startx - 1; i++)
                {
                    res[i][j] = num++;
                }
                //矩阵底层，从右到左
                for (; j > starty; j--)
                {
                    res[i][j] = num++;
                }
                //矩阵左层，从下到上
                for (; i > startx; i--)
                {
                    res[i][j] = num++;
                }
                loop--;
                (startx, starty) = (startx + 1, starty + 1);

            }
            if (n % 2 == 1)
            {
                res[n / 2][n / 2] = num;
            }
            return res;

        }
    }
}
