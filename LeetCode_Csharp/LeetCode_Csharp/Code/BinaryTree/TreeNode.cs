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
    public class BinaryTree: BinaryTree<int>
    {
        public BinaryTree()
        {
            rootNode = null;
        }

        public BinaryTree(int data)
        {
            rootNode = new TreeNode<int>(data);
        }

        public void Insert(int data)
        {
            TreeNode<int> newNode = new TreeNode<int>(data);
            if(rootNode == null)
            {
                rootNode = newNode;
                return;
            }

            Queue<TreeNode> queue = [];
            queue.Enqueue(rootNode as TreeNode);
            while(queue.Count > 0)
            {
                int size = queue.Count;
                while(size-- > 0)
                {
                    TreeNode<int> node = queue.Dequeue();
                    if(node.left is null)
                    {
                        node.left = newNode;
                        return;
                    }
                    if(node.right is null)
                    {
                        node.right = newNode;
                        return;
                    }
                    if(node.left is not null)
                    {
                        queue.Enqueue(node.left as TreeNode);
                    }
                    if(node.right is not null)
                    {
                        queue.Enqueue(node.right as TreeNode);
                    }
                }
            }

        }
    }
    public class BST<T> 
    where T: IComparable<T>
    {
        public TreeNode<T> root;

        public BST()
        {
            root = null;
        }

        public BST(T data)
        {
            root = new TreeNode<T>(data);
        }

        public TreeNode<T> Insert(TreeNode<T> root ,T val)
        {
            if(root is null)
            {
                root = new TreeNode<T>(val);
                return root;
            }

            if(root.val.CompareTo(val) > 0)
            {
                root.left = Insert(root.left, val);
            }
            else
            {
                root.right = Insert(root.right, val);
            }
            return root;
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
