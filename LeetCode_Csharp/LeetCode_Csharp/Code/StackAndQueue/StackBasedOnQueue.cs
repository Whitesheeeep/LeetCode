using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LeetCode_Csharp.Code.StackAndQueue
{
    public class StackBasedOnQueue
    {
        public class MyStack
        {
            private Queue<int> queue;
            public MyStack()
            {
                queue = new Queue<int>();
            }

            public void Push(int x) {
                queue.Enqueue(x);
            }
            
            public int Pop() {
                if(queue.Count == 0) return default(int);
                for(int i = 0; i < queue.Count - 1; i++) 
                {
                    int temp = queue.Dequeue();
                    queue.Enqueue(temp);
                }
                return  queue.Dequeue();
                
            }
            
            public int Top() {
                int temp = this.Pop();
                Push(temp);
                return temp;
            }
            
            public bool Empty() {
                return queue.Count == 0;
            }
        }
    }
}
