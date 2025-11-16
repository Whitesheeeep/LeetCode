#pragma once
#ifndef BINARYTREE_H
#define BINARYTREE_H

#include <iostream>
#include <stack>
#include <queue>
#include <vector>

using namespace std;

template <typename T>
class TreeNode
{
public:
    T data;
    TreeNode<T> *left;
    TreeNode<T> *right;

    TreeNode(T data, TreeNode<T> *left = nullptr, TreeNode<T> *right = nullptr)
    {
        this->data = data;
        this->left = left;
        this->right = right;
    }
};

template <typename T>
class BinaryTree
{
public:
    TreeNode<T> *rootNode;

    BinaryTree()
    {
        rootNode = nullptr;
    }

    BinaryTree(T num)
    {
        rootNode = new TreeNode<T>(num);
    }

    void PreOrderTraversal(TreeNode<T> *rootNode)
    {
        if (rootNode == nullptr)
            return;
        cout << rootNode->data << endl;
        PreOrderTraversal(rootNode->left);
        PreOrderTraversal(rootNode->right);
    }

    void PreOrderTraversal_Iteration(TreeNode<T> *rootNode)
    {
        stack<TreeNode<T> *> s;
        TreeNode<T> *cur = rootNode;

        while (cur != nullptr || !s.empty())
        {
            while (cur != nullptr)
            {
                s.push(cur);
                cout << cur->data << endl;
                cur = cur->left;
            }
            if (!s.empty())
            {
                cur = s.top();
                s.pop();
                cur = cur->right;
            }
        }
    }

    void MiddleOrderTraversal(TreeNode<T> *rootNode)
    {
        if (rootNode == nullptr)
            return;
        MiddleOrderTraversal(rootNode->left);
        cout << rootNode->data << endl;
        MiddleOrderTraversal(rootNode->right);
    }

    void MiddleOrderTraversal_Iteration(TreeNode<T> *rootNode)
    {
        if (rootNode == nullptr)
            return;
        stack<TreeNode<T> *> s;
        TreeNode<T> *cur = rootNode;

        while (cur != nullptr || !s.empty())
        {
            while (cur != nullptr)
            {
                s.push(cur);
                cur = cur->left;
            }
            if (!s.empty())
            {
                cur = s.top();
                s.pop();
                cout << cur->data << endl;
                cur = cur->right;
            }
        }
    }

    // 后续遍历：前序遍历是 中左右，后序遍历是 左右中，我们直接改变前序遍历的使其中右左，然后颠倒即可得到左右中

    void Insert(TreeNode<T> *node)
    {
        if (rootNode == nullptr)
        {
            rootNode = node;
            return;
        }

        queue<TreeNode<T> *> nodeQue;
        nodeQue.push(rootNode);
        while (!nodeQue.empty())
        {
            TreeNode<T> *tempNode = nodeQue.front();
            nodeQue.pop();

            if (tempNode->left == nullptr)
            {
                tempNode->left = node;
                return;
            }
            else
                nodeQue.push(tempNode->left);

            if (tempNode->right == nullptr)
            {
                tempNode->right = node;
                return;
            }
            else
                nodeQue.push(tempNode->right);
        }
    }

#pragma region 层序遍历
    void LevelOrderTraversal(TreeNode<T> *node)
    {
        if (node == nullptr)
            return;
        queue<TreeNode<T> *> nodeQue;
        nodeQue.push(node);

        while (!nodeQue.empty())
        {
            T size = nodeQue.size();
            while (size--)
            {
                TreeNode<T> *temp = nodeQue.front();
                nodeQue.pop();
                cout << temp->data << endl;
                if (temp->left != nullptr)
                {
                    nodeQue.push(temp->left);
                }
                if (temp->right != nullptr)
                    nodeQue.push(temp->right);
            }
        }
    }

#pragma endregion

    void Insert(T i)
    {
        TreeNode<T> *ptr = new TreeNode<T>(i);
        Insert(ptr);
    }
    static TreeNode<int> *BuildTreeFromArray(const vector<int> &nums)
    {
        if (nums.empty())
        {
            throw runtime_error("Nums are null or has no thing!");
            return nullptr;
        }
        TreeNode<int> *head = new TreeNode(nums[0]);
        int index = 1; // 指示当前要插入的内容的指针。
        // 层序遍历输入
        queue<TreeNode<int> *> que;
        que.push(head);
        while (!que.empty())
        {
            int size = que.size();
            while (size--)
            {
                TreeNode<int> *temp = que.front();
                que.pop();

                if (index >= nums.size())
                    return head;
                // -1 表示空指针
                if (nums[index] != -1 && temp->left == nullptr)
                {
                    temp->left = new TreeNode(nums[index]);
                    que.push(temp->left);
                }
                index++;
                if (index >= nums.size())
                    return head;
                if (nums[index] != -1 && temp->right == nullptr)
                {
                    temp->right = new TreeNode(nums[index]);
                    que.push(temp->right);
                }
                index++;
            }
        }
        return head;
    }

    static void LevelPrintTree(TreeNode<int> *head)
    {
        if (head == nullptr)
            throw runtime_error("传入指针为空");

        queue<TreeNode<int> *> que;
        que.push(head);

        while (!que.empty())
        {
            int size = que.size();
            while (size--)
            {
                /* code */
                TreeNode<int> *node = que.front();
                que.pop();
                cout << node->data << " ";
                if (node->left)
                    que.push(node->left);
                if (node->right)
                    que.push(node->right);
            }
            cout << endl;
        }
    }
};

#endif
