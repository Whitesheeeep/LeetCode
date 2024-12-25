# LeetCode232_QueueBasedOnStack_Easy

## C# Stack 和 Queue

[Stack 和 Queue](https://www.cnblogs.com/teroy/p/4374206.html)实现，对应底层代码[C# Stack、Queue](https://referencesource.microsoft.com/#mscorlib/system/collections/stack.cs,52293d65ba832461)。

但是在 C++ 还涉及到容器与容器适配器概念，详情请看代码随想录[栈与队列理论基础](https://programmercarl.com/%E6%A0%88%E4%B8%8E%E9%98%9F%E5%88%97%E7%90%86%E8%AE%BA%E5%9F%BA%E7%A1%80.html)并对应咨询 AI。

## 题目思路

双栈模拟队列：
这里思路就是用两个栈来存储数据：stackIn, stackOut。
Push 就很简单的，将 数据 Push 进 stackIn 即可，主要就是 Pop，每次我们不可能得到 stackIn 的底部，所以我们需要第二个栈 stackOut，在每一次需要 Pop 的时候我们将 stackIn 数据传入 stackOut，但是反向输入，这个很简单，stackIn Pop 出来的穿进去刚好是 stackOut 的底部，然后 Pop stackOut 的数据即可。而且不用将 stackIn 的数据还回去，因为我们不用管中间数据存储在那个 stack ，我们只关心 传入的以及将传出的，而且数据在两个 stack 中反而会导致数据问题（数据重复），因此我们大胆放心 stackIn.pop 和 stackOut 即可。

最后注意一点是，C# 中 stack 是没有判断是否为空的 empty 函数的（老版本有，微软罪大恶极，而且 stack 是值类型，不能用 null 判断），所有我们判 stack 空的时候要用 `stack.Count == 0;` 。

最后代码：

```C#
public class MyQueue {

    private Stack<int> stackIn;
            private Stack<int> stackOut;

            public MyQueue()
            {
                stackIn = new Stack<int>();
                stackOut = new Stack<int>();
            }

            public void Push(int x)
            {
                stackIn.Push(x);
            }

            public int Pop()
            {
                if(stackOut.Count == 0)
                {
                    while(stackIn.Count > 0)
                    {
                        stackOut.Push(stackIn.Pop());
                    }
                }
                return stackOut.Pop();
            }

            public int Peek()
            {
                int result = this.Pop();
                stackOut.Push(result);
                return result;
            }

            public bool Empty()
            {
                return stackIn.Count == 0 && stackOut.Count == 0;
            }
}

/**
 * Your MyQueue object will be instantiated and called as such:
 * MyQueue obj = new MyQueue();
 * obj.Push(x);
 * int param_2 = obj.Pop();
 * int param_3 = obj.Peek();
 * bool param_4 = obj.Empty();
 */
```
