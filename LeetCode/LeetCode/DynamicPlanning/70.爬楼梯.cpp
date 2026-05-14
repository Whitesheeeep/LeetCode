#include <iostream>
#include <vector>

using namespace std;

int climbMethods(int n){
    // f(i) 表示 达到第 i 级阶梯会有多少种方法
    // 1 个台阶 f(i) = f(i-1)
    // 2 个台阶 f(i) = f(i - 2)
    if (n == 1) {
        return 1;
    }
    vector<int> res(n, 0);
    res[0] = 1;
    res[1] = 2;

    for (int i = 2; i < n; i++) {
        res[i] = res[i - 1] + res[i - 2];
    }
    return res[n - 1];
}

int main(){
    while (true) {
    {int n;
    cin >> n;
    cout << climbMethods(n) << endl;}}
}
