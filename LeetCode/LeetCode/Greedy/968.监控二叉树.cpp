#include <iostream>
#include <queue>
#include <vector>

using namespace std;

class TreeNode
{
public:
    int val;
    TreeNode* left, *right;
    TreeNode(): val(0), left(nullptr), right(nullptr){}
    TreeNode(int x) : val(x), left(nullptr), right(nullptr) {}
    TreeNode(int x, TreeNode *left, TreeNode *right) : val(x), left(left), right(right) {}
};

int handleMonitor(queue<int>& que, vector<int>& tree, vector<bool>& monitored, int node){
    if (tree[node] == -1) {
        return 0;
    }
    int res = 0;
    int left = node * 2 + 1, right = node * 2 + 2;
    if (tree[left] == -1 && tree[right] == -1) {
        return 1;
    }

    if (tree[left] == -1 || tree[right] == -1){
        res++;
        int tempNode = tree[left] == -1 ? tree[right] : tree[left];
        int tempL = 2 *  tempNode  + 1, tempR = 2 * tempNode + 2;
        que.push(tempL);
        que.push(tempR);
    }

    // 二者都不为空
    
    return res;
}

int minCameraCover(vector<int>& tree){
    // 2i + 1 为 l， 2i + 2 为 r
    // 层序遍历，前序遍历
    int res = 0;
    queue<int> noMonitorTreeNode;
    vector<bool> monitored(tree.size(), false);
    noMonitorTreeNode.push(0);

    while (!noMonitorTreeNode.empty()) {
        int node = noMonitorTreeNode.front(); noMonitorTreeNode.pop();
        
    }
}

int main(){
    int n, node;
    cin >> n;
    vector<int> tree;

    // -1 为 无
    while (n--) {
        cin >> node;
        tree.push_back(node);
    }


}
