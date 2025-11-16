#include "../头文件/BinaryTree.H"
#include <iostream>
using namespace std;

int main() {
    #pragma region 简单树创建
    // 使用 int 类型创建二叉树节点并构造一个简单树
    /* TreeNode<int>* root = new TreeNode<int>(1);
    root->left = new TreeNode<int>(2);
    root->right = new TreeNode<int>(3);
    root->left->left = new TreeNode<int>(4);
    root->left->right = new TreeNode<int>(5);

    // 构造 BinaryTree 并设置根节点
    BinaryTree<int> tree;
    tree.rootNode = root;
    
    // 中序遍历（传入根节点）
    system("chcp 65001 > nul");
    cout << endl;
    cout << "中序遍历—递归" << endl;
    tree.MiddleOrderTraversal(tree.rootNode);

    cout << "中序遍历-迭代" << endl;
    tree.MiddleOrderTraversal_Iteration(tree.rootNode);

    cout << "先序遍历-递归" << endl;
    tree.PreOrderTraversal(tree.rootNode);

    cout << "先序遍历-迭代" << endl;
    tree.PreOrderTraversal_Iteration(tree.rootNode);

    cout << "层序遍历" << endl;
    tree.LevelOrderTraversal(tree.rootNode); */
    #pragma endregion

    #pragma region 数组树创建
    vector<int> nums{1,2,3,4,5};
    // for(int i : nums) cout << i;
    auto head = BinaryTree<int>::BuildTreeFromArray(nums);
    BinaryTree<int>::LevelPrintTree(head);
    nums.pop_back();
    
    #pragma endregion

    return 0;
}
