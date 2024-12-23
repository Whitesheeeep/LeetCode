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
    
        public int[][] GenerateMatrix2(int n)
        {
            int[][] res = new int[n][];
            for (int i = 0; i < n; i++)
            {
                res[i] = new int[n];
            }

            //初始化
            int left = 0, right = n - 1, top = 0, bottom = n - 1;
            int num = 1;
            while (left <= right && top <= bottom)
            {
                //从左到右
                for (int i = left; i <= right; i++)
                {
                    res[top][i] = num++;
                }
                //从上到下
                for (int i = top + 1; i <= bottom; i++)
                {
                    res[i][right] = num++;
                }
                //从右到左
                for (int i = right - 1; i >= left; i--)
                {
                    res[bottom][i] = num++;
                }
                //从下到上
                for (int i = bottom - 1; i > top; i--)
                {
                    res[i][left] = num++;
                }
                left++;
                right--;
                top++;
                bottom--;
            }


            return res;         
        }
    }
}
