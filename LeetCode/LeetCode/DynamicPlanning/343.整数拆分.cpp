#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

int getMaxMulti(int n) {
	// f(i) 表示 数字为 i 时的最大乘数
	vector<int> res(n + 1, 0);
    res[2] = 1;
    
    for (int i = 3; i <= n; i++) {
        for (int j = 1; j <= i/2; j++) {
            res[i] = max(res[i], max(j * res[i - j], j * (i- j)));
        }
    }
    return res[n];
}

int main() {
    while (true) {
        {
            int n;
            cin >> n;	
            cout << getMaxMulti(n) << endl;
        }
    }
}
