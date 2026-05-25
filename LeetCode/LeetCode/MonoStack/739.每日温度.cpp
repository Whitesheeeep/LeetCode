#include <iostream>
#include <random>
#include <stack>
#include <vector>

using namespace std;

vector<int> dailyTemperature(std::vector<int>& temperatures){
    stack<int> index;
    vector<int> res(temperatures.size(), 0);

    for (int i = temperatures.size()-1; i >= 0; i--) {
        if (index.empty()) {
            res[i] = 0;
            index.push(i);
        }
        else {
            int topIndex = index.top();
            if (temperatures[i] < temperatures[topIndex]) {
                res[i] = topIndex;
                index.push(i);
            }
            else { //  本位 >= 栈位
                while (!index.empty() && temperatures[index.top()] <= temperatures[i]) {
                    index.pop();
                }
                if (index.empty()) {
                    res[i] = 0;
                }
                else {
                    res[i] = index.top();
                }
                index.push(i);
            }
        }
    }
    return res;
}

void DebugRes(vector<int>& res)
{
    for (int i = 0; i < res.size(); i++) {
        cout << i << " " << res[i] << endl;
    }
}

int main(){
    random_device rd;
    mt19937 gen(rd());
    uniform_int_distribution<int> distrib(0,100);
    vector<int> test1(6);
    for (int i = 0; i < test1.size(); i++) {
        test1[i] = distrib(gen);
        cout << test1[i] << " ";
    }
    cout << endl;
    
    vector<int> res1 = dailyTemperature(test1);
    DebugRes(res1);
}
