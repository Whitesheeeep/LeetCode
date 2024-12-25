# LeetCode142 环型链表II

> [LeetCode142 环形链表链接](https://leetcode.cn/problems/linked-list-cycle-ii/description/)

## Solution1 ：哈希表：把已经遍历过的节点用哈希表存起来

这里先简单学习一下 C# 的用哈希表实现的数据结构 HashSet\<T\>：
> HashSet\<T\>:
> 文档：[HashSet](https://learn.microsoft.com/zh-cn/dotnet/api/system.collections.generic.hashset-1?view=net-9.0)
> Add 加入元素，Contains 查询是否包含元素，Remove 去除元素。其他方法请查看 API 或者 咨询AI
> 它的实现基于哈希表，提供了一种无序集合的实现，具有快速插入、删除和查找的特性。
> **特点：**
>
> 1. 唯一性：HashSet\<T\> 不允许存储重复的元素。
> 2. 无序存储：元素存储的顺序与插入顺序无关。
> 3. 高效操作：插入、删除和查找的平均时间复杂度为 O(1)。
> 4. 基于哈希表：使用哈希值来组织和快速访问元素。
> 5. 支持自定义比较器：可以提供自定义的 IEqualityComparer\<T\> 实现来改变哈希计算或比较逻辑。

主要思路就是逐步遍历链表，每次遍历将链表放入哈希表中，并且在遍历的时候判断该元素是否存在于哈希表中，如果存在说明有环，而且第一次查询到的记为环的入口。
C# 实现代码如下：

```C#
public ListNode DetectCycle(ListNode head)
{
    if(head == null || head.next == null) return null;
    HashSet<ListNode> hashSet = new HashSet<ListNode>();
    ListNode current = head;
    while(current != null && hashSet.Contains(current) == false)
    {
        hashSet.Add(current);
        if(current.next == null) return null;
        current = current.next;
    }
    return current;
}
```

## Solution2 : 快慢指针 结合 数学思想

我们采用快慢指针的方式来遍历，但是快指针每次走两步，慢指针每次走一步：
![alt text](Img_LeetCode142_md\image-1.png)
首先，fast 指针肯定比 slow 指针先进入环中，如果 fast 与 slow 指针相遇也一定是在环中相遇的。这是很简单证明的。
> 为什么 fast 指针和 slow 指针一定会相遇？证明：
> ***
> **证明方式一：**
> 我们假设经过次数 t ，二者相遇，环的节点数为 s
> 那么根据追及相遇问题可知：二者相遇的时候
> fast移动-slow移动 = ns, n 为正整数
> 即：2t - t = ns => t = ns, n = 1,2,3,……
> 可以解得，t 是有解的，那么也就是说二者是会相遇的
> 而且我们可以发现，此时 slow 指针刚好走一个环的节点数，那么我们假设进入换之前的节点数为 z，那么此时 slow 指针（其实也是 fast 指针，只不过 slow 指针是每次走一步，使用指针比较适合以下的步骤）在环内走过的格子数为 s-z，再走 z 格就到了环的入口，那么我们在 head 处再设置一个指针 ptr，同时按照每次一格走，ptr 与 slow 相遇的地方就是环的入口。
> ***
> **证明方式二：**
> 见[LeetCode142](https://leetcode.cn/problems/linked-list-cycle-ii/solutions/441131/huan-xing-lian-biao-ii-by-leetcode-solution/) 的评论区中 Shawing 精讲算法。只补充一点：他的评论中说再经过 y 个单位时间即可追上 slow 可以用相对速度的方法思考就可以证明。
> ***
> **证明方式三：**
> 当然，还有一种思路，当slow 进入的时候，这时候我们看相对速度，也就是相当于fast 在一个一个各自慢慢接近slow指针，不论怎样，此时发现，在一圈之内，fast 一定能追上 slow ，也就是说 slow 被追上的时候肯定是没有在环内走过超过一圈的。
>
那么代码编写就是用fast ，slow移动，然后第一次相遇的时候在停止，在head再次定义一个指针一个单位每次的速度移动，当其与 slow 指针相遇的时候，二者所指向的节点就是入口节点。
代码如下；

```C#
public ListNode DetectCycle2(ListNode head)
{
    if(head == null || head.next == null) return null;
    ListNode slow = head, fast = head;

    //第一次相遇，同时判断是否有环
    while(fast != null && fast.next != null)
    {
        fast = fast.next.next;
        slow = slow.next;

        if(fast == slow)
        {
            ListNode newP = head;
            while(slow != newP)
            {
                slow = slow.next;
                newP = newP.next;
            }
            return newP;
        }
    }
    return null;
}
```
