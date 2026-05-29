#include <iostream>
#include <vector>

using namespace std;


int canCompleteCircuit(vector<int>& gas, vector<int>& cost){
    int index = -1;

    // 前往下一个站的油量 delta
    vector<int> delta(gas.size(), 0);
    for (int i = 0; i < gas.size(); i++) {
        delta[i] = gas[i] - cost[i];
    }

    for (int i = 0; i < delta.size(); i++) {
        if (delta[i] < 0) continue;

        int remain = delta[i];
        int ptr = i;
        while (remain >= 0) {
            ptr = (ptr + 1) % delta.size();
            remain += delta[ptr];
            if (ptr == i) {
                return i;
            }
        }
        i = ptr++;
    }

    return index;
}

int main()
{
    int gN, gI, cN, cI;
    cin >> gN;

    vector<int> gas, cost;

    while (gN--) {
        cin >>gI;
        gas.push_back(gI);
    }

    cin >> cN;
    while (cN--) {
        cin >> cI;
        cost.push_back(cI);
    }

    cout << canCompleteCircuit(gas, cost);
}
