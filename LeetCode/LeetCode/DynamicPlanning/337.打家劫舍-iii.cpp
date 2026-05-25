#include <algorithm>
#include <iostream>
#include <queue>
#include <vector>

using namespace std;

struct TreeNode {
    int money;
    TreeNode *left, *right;
    TreeNode() : money(0), left(nullptr), right(nullptr) {}
    TreeNode(int val) : money(val), left(nullptr), right(nullptr) {}
    TreeNode(int val, TreeNode *leftP, TreeNode *rightP)
        : money(val), left(leftP), right(rightP) {}
};


int maxStoleMoney(TreeNode* root){
    if (root == nullptr) {
        return 0;
    }

    // 偷
    if (!root->left && !root->right) {
        return root->money;
    }
    // 偷 root
    int leftMoney = 0;
    if (root->left) {
        int ll = maxStoleMoney(root->left->left);
        int lr = maxStoleMoney(root->left->right);
        leftMoney = ll + lr;
    }
    // cout << "leftMoney " << leftMoney << endl;
    int rightMoney = 0;
    if (root->right) {
        int rl = maxStoleMoney(root->right->left);
        int rr = maxStoleMoney(root->right->right);
        rightMoney = rl + rr;
    }
    // cout << "rightMoney " << rightMoney << endl;
    int stole = leftMoney + rightMoney + root->money;
    return max(stole, maxStoleMoney(root->left) + maxStoleMoney(root->right));
}

TreeNode *builTree(vector<int> &nums) {
    if (nums.empty() || nums.size() == 0) {
        return nullptr;
    }

    TreeNode *root = new TreeNode(nums[0]);
    // 层序处理
    queue<TreeNode *> q;
    q.push(root);
    int i = 1;
    while (!q.empty() && i < nums.size()) {
        auto curNode = q.front();
        q.pop();

        if (i < nums.size() && nums[i] != -1) {
            curNode->left = new TreeNode(nums[i]);
            q.push(curNode->left);
        }
        i++;

        if (i < nums.size() && nums[i] != -1) {
            curNode->right = new TreeNode(nums[i]);
            q.push(curNode->right);
        }
        i++;
    }
    return root;
}

int main() {
    cout << "test1" << endl;
    vector<int> test1{1,1,1};
    TreeNode* t1 = builTree(test1);
    cout << "res: " << endl;
    cout << maxStoleMoney(t1) << " right: 2" << endl;
    cout << "test1 over" << endl;
    cout << endl;

    cout << "test2" << endl;
    vector<int> test2{3,1,1};
    TreeNode* t2 = builTree(test2);
    cout << "res: " << endl;
    cout << maxStoleMoney(t2) << " right: 3" << endl;
    cout << "test2 over" << endl;
    cout << endl;

    cout << "test3" << endl;
    vector<int> test3{1,1,1,1,1,1,1};
    TreeNode* t3 = builTree(test3);
    cout << "res: " << endl;
    cout << maxStoleMoney(t3) << " right: 3" << endl;
    cout << "test3 over" << endl;
    cout << endl;

    // int n;
    // cin >> n;
    // vector<int> nums(n, 0);
    // for (int i = 0; i < n; i++) {
    //     cin >> nums[i];
    // }
}
