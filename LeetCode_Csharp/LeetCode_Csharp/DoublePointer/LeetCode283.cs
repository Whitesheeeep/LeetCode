using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.DoublePointer
{
    public class LeetCode283
    {
        //Solution1：反向思考，找数组中不为 0 的元素
        public void MoveZeros(int[] nums)
        {
            int slow = 0;
            int fast;
<<<<<<< HEAD
            // int temp;
=======
            int temp;
>>>>>>> bc108098278a63eac876d2ae529692c28ace0157
            for (fast = 0; fast < nums.Length; fast++)
            {
                if(nums[fast] != 0)
                {
                    //使用交换方法也可以，因为每次交换都是0，所以不会有问题
                    //temp = nums[slow];
                    nums[slow] = nums[fast];
                    //nums[fast] = temp; 

                    //下面这一步可以省去一个for循环
                    if(fast > slow) nums[fast] = 0;
                    slow++;
                    continue;
                }

            }

            // for(;slow < nums.Length; slow++)
            // {
            //     nums[slow] = 0;
            // }




        }
    }
}