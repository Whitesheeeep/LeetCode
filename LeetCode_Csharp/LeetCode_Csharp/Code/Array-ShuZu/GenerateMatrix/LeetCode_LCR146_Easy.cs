using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.GenerateMatrix
{
    public class LeetCode_LCR146_Easy
    {
        public int[] SpiralArray(int[][] array)
        {
            if(array.Length == 0) return [];
            int m = array.Length, n = array[0].Length;
            int[] result = new int[m * n];
            int index = 0;
            //定义边界
            int left = 0, right = n - 1, top = 0, bottom = m - 1;
            while(true)
            {
                for(int i = left; i <= right; i++)
                {
                    result[index++] = array[top][i];
                }
                
                if(++top > bottom) break;
                for(int i = top; i <= bottom; i++)
                {
                    result[index++] = array[i][right];
                }

                if(--right < left) break;
                for(int i = right; i >= left && top <= bottom; i--)
                {
                    result[index++] = array[bottom][i];
                }

                if(--bottom < top) break;
                for(int i = bottom; i >= top && left <= right; i--)
                {
                    result[index++] = array[i][left];
                }

                if(++left > right) break;
            }
            

            return result;
        }
    }
}
