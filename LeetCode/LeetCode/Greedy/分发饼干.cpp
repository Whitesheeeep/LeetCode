#include <algorithm>
#include <iostream>
#include <vector>

using namespace std;

class Solution{
public:
    int findContentChildren(vector<int>& g, vector<int>& s)
    {
        sort(g.begin(), g.end());
        sort(s.begin(), s.end());

        int g_ptr = 0, res = 0;
        for (int a : s) {
            if (g_ptr < g.size() && a >= g[g_ptr]){
                res++;
                g_ptr++;
                if (g_ptr == g.size()) break;
            }
        }
        return res;
    }
};

int main()
{
    int gNum, sNum, g_Input, s_Input;
    cin >> gNum;
    vector<int> g;
    while (gNum--) {
        cin >> g_Input;
        g.push_back(g_Input);
    }
    cin >> sNum;
    vector<int> s;
    while (sNum--) {
        cin >> s_Input;
        s.push_back(s_Input);
    }

    Solution* sln = new Solution();
    cout << sln->findContentChildren(g, s);
}
