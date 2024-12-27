using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.StackAndQueue
{
    public class LeetCode239_maxSlidingWindow_hard
    {
        public int[] MaxSlidingWindow(int[] nums, int k)
        {
            MyQueue myQueue = new MyQueue();
            // int[] result = new int[nums.Length - k + 1];
            List<int> result = new List<int>();

            //初始化窗口
            for (int i = 0; i < k; i++)
            {
                myQueue.Enqueue(nums[i]);
            }
            // result[0] = myQueue.Max();
            result.Add(myQueue.Max());

            for (int i = k; i < nums.Length; i++)
            {
                myQueue.Dequeue(nums[i - k]);
                myQueue.Enqueue(nums[i]);
                // result[i - k + 1] = myQueue.Max();
                result.Add(myQueue.Max());
            }

            return result.ToArray();
        }

        public class MyQueue
        {
            //First 是尾巴，Last 是头
            //从右往左的队列
            private LinkedList<int> queue = new LinkedList<int>();

            public void Dequeue(int val)
            {
                if (queue.Count > 0 && val == queue.First.Value)
                {
                    queue.RemoveFirst();
                }
            }

            public void Enqueue(int val)
            {
                while (queue.Count > 0 && queue.Last.Value < val)
                {
                    queue.RemoveLast();
                }
                queue.AddLast(val);
            }

            public int Max()
            {
                return queue.First.Value;
            }

        }
    }
}
