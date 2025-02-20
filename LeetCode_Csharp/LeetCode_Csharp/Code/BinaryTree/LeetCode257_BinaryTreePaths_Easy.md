# LeetCode257_BinaryTreePaths 二叉树的所有路径_Easy

> [LeetCode257 二叉树的路径](https://leetcode.cn/problems/binary-tree-paths/description/)
> [代码随想录 二叉树的所有路径](https://programmercarl.com/0257.%E4%BA%8C%E5%8F%89%E6%A0%91%E7%9A%84%E6%89%80%E6%9C%89%E8%B7%AF%E5%BE%84.html#%E7%AE%97%E6%B3%95%E5%85%AC%E5%BC%80%E8%AF%BE) 这里还讲解了一些注意事项。
> **tag:** 前序遍历，回溯

本体思路很简单，根据题目就可以知道采用前序遍历，然后判断空节点，如果为空节点则构成 string 并加入结果，然后回溯到上一个节点继续递归（或者遍历）。

主要在于如何处理代码，如何进行回溯，何处回溯。

主要理解回溯的处理，将遍历过的 treeNode 装进 List\<treeNode\> 中，每次处理结束后将 List\<ListNode\> 中的后一位删去，即为回溯到上一个节点中，即为回溯。

**代码如下：**

```C#
public IList<string> BinaryTreePaths(TreeNode root)
{
    List<TreeNode> treeNodes = new();
    List<string> result = new();
    // if(root is null) return result;
    DFS(root, treeNodes, result);
    return result; 

}

// 第一部分：递归函数，递归函数的参数，递归函数的返回值
// treeNodes：存储当前路径上的所有节点，同时用于回溯
// result：存储结果
public void DFS(TreeNode node, List<TreeNode> treeNodes, List<string> result)
{
    if(node is null) return;
    treeNodes.Add(node);
    // 第二部分：递归终止条件
    // 如果当前节点是叶子节点，将当前路径上的所有节点的值拼接成字符串，添加到结果中
    if(node.left is null && node.right is null)
    {
        StringBuilder sb = new();
        for(int i = 0; i < treeNodes.Count; i++)
        {
            sb.Append(treeNodes[i].val);
            if(i < treeNodes.Count - 1)
            {
                sb.Append("->");
            }
        }
        result.Add(sb.ToString());
        return;
    }

    // 第三部分：递归函数的逻辑
    // 如果当前节点不是叶子节点，将当前节点添加到路径中，继续递归左右子节点
    // 注意回溯，回溯与递归同时进行
    // 注意条件，有可能左子结点为空，所以要判断左子结点是否为空
    if(node.left is not null)
    {
        DFS(node.left, treeNodes, result);
        // 回溯
        treeNodes.RemoveAt(treeNodes.Count - 1);
    }
    if(node.right is not null)
    {
        DFS(node.right, treeNodes, result);
        // 回溯
        treeNodes.RemoveAt(treeNodes.Count - 1);
    }
}
```

## 精简代码

这里的回溯体现在 Traversal 的 string 参数传入中，利用的是方法传递 string 传递的是副本。这样处理完 node.left 后所使用的 str 就是回溯后的 str。

```C#
public IList<string> BinaryTreePaths2(TreeNode root)
{
    string str = "";
    List<string> result = new();
    
    Traversal(root, str, result);
    return result; 
}

public void Traversal(TreeNode node, string str, List<string> result)
{
    if(node is null) return;
    str += node.val;
    if(node.left is null && node.right is null)
    {
        result.Add(str);
        return;
    }
    if(node.left is not null) Traversal(node.left, str + "->" , result);
    if(node.right is not null) Traversal(node.right, str + "->" , result);
}
```
