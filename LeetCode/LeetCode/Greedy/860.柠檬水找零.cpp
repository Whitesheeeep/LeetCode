#include <iostream>
#include <vector>

using namespace std;

bool canReturn(vector<int>& bills){
    vector<int> haveMoney(3, 0); // 0-1 对应 5 - 10 

    for (int i = 0; i < bills.size(); i++) {
        if (bills[i] == 5) {
            haveMoney[0]++;
        }
        else if (bills[i] == 10) {
            haveMoney[0]--;
            haveMoney[1]++;
            if (haveMoney[0] < 0) {
                return false;
            }
        }
        else if (bills[i] == 20) {
            // 方案 1： 10 + 5
            if (haveMoney[1] > 0 && haveMoney[0] > 0) {
                haveMoney[0]--;
                haveMoney[1]--;
                haveMoney[2]++;
            }
            else if (haveMoney[0] >= 3) {
                haveMoney[0] -= 3;
                haveMoney[2]++;
            }
            else {
                return false;
            }
        }
    }

    return true;
}

int main(){
    while (true) 
    {int  n, k;
    cin >> n;
    vector<int> bills;
    while (n--) {
        cin >> k;
        bills.push_back(k);
    }

    cout << canReturn(bills);}
}
