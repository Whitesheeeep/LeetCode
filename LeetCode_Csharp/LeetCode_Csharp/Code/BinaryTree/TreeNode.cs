namespace LeetCode_Csharp.Code.BinaryTree
{
    using System;
    public class TreeNode: TreeNode<int>
    {
        public new TreeNode left;
        public new TreeNode right;

        public TreeNode(int val): base(val)
        {
            this.val = val;
            left = null;
            right = null;
        }
    }

    public class TreeNode<T>
    {
        public TreeNode<T> left;
        public TreeNode<T> right;
        public T val;

        public TreeNode(T data)
        {
            this.val = data;
            left = null;
            right = null;
        }
    }

    public class BinaryTree<T>
    {
        public TreeNode<T> rootNode;

        public BinaryTree()
        {
            rootNode = null;
        }

        public BinaryTree(T data)
        {
            rootNode = new TreeNode<T>(data);
        }

        #region 前序遍历
        // InOrder Traversal 根节点 -> 左子树 -> 右子树，递归实现
        public void PreOrderTraversal(TreeNode<T> node)
        {
            if (node == null)
            {
                return;
            }

            Console.WriteLine(node.val);
            PreOrderTraversal(node.left);
            PreOrderTraversal(node.right);
        }
        public void PreOrderTraversal()
        {
            PreOrderTraversal(rootNode);
        }

        // InOrder Traversal 前序遍历：根节点 -> 左子树 -> 右子树，迭代实现
        public void PreOrderTraversal2(TreeNode<T> node)
        {
            if(node == null) return;

            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            TreeNode<T> current = node;
            while(current != null || stack.Count > 0)
            {
                while(current != null)
                {
                    stack.Push(current);
                    Console.WriteLine(current.val);
                    current = current.left;
                }
                if (stack.Count > 0)
                {
                    current = stack.Pop();
                    current = current.right;
                }
            }
        }
        public void PreOrderTraversal2()
        {
            PreOrderTraversal2(rootNode);
        }
    }
    #endregion 前序遍历
}
