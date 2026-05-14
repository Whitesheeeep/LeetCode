#include <iostream>
#include <vector>

using namespace std;

int countTree(int n) {
    // f(i)：1 - i 所能够获取的二叉搜索树个数
    // 推导：
    // 对于 n 中取 i 作为 root，则 1 ~ i-1 作为 root 的左子树，i+1 ~ n
    // 为右子树， f(n) += for i in range(1, n) f(i) * f(n - i)
    if (n <= 1) {
        return 1;
    }
    vector<int> res(n + 1, 0);
    res[0] = 1;
    res[1] = 1;
    res[2] = 2;
    for (int i = 3; i <= n; i++) {
        for (int j = 0; j < i; j++) {
            res[i] += res[j] * res[i - j - 1];
        }
    }
    return res[n];
}

int main() {
    while (true) {
        int n;
        cin >> n;
        cout << countTree( n) << endl;
    }
}
