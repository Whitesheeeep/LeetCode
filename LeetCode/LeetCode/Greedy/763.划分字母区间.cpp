#include <algorithm>
#include <iostream>
#include <unordered_map>
#include <unordered_set>
#include <utility>
#include <vector>

using namespace std;

struct partition{
    int start, end;
    unordered_set<char> containsAlpha;
};

vector<int> deleteRepeat(vector<pair<int, int>>& pairs){
    for (int i = pairs.size() - 1; i >=0; i--) {
        if (pairs[i].first == -1) {
            pairs.erase(pairs.begin() + i);
        }
    }
    sort(pairs.begin(), pairs.end(), [](pair<int, int>& a, pair<int, int>& b){
        if (a.first == b.first) {
            return a.second < b.second;
        }
        return a.first < b.first;
    });

    for (int i = 0; i < pairs.size(); i++) {
        cout << "pairs" << i << ": " << pairs[i].first << pairs[i].second << endl;
    }

    unordered_map<int, int> stoe;
    int left= pairs[0].first, right = pairs[0].second;
    for (int i = 1; i < pairs.size(); i++) {
        int start = pairs[i].first, end = pairs[i].second;
        if (start <= right) {
            right = max(right, end);
            stoe[left] = right;
        }
        else {
            left = start;
            right = end;
            stoe[left] = right;
        }
        // cout << i << " : " << stoe[left] << " "  << end << endl;
    }
    
    vector<pair<int, int>> res;
    for (auto a : stoe) {
        res.push_back({a.first, a.second});
    }
    sort(res.begin(), res.end(), [](pair<int, int>& a, pair<int, int>& b){
        if (a.first == b.first) {
            return a.second < b.second;
        }
        return a.first < b.first;
    });
    vector<int> c;
    for (auto a : res){
        c.push_back(a.second - a.first + 1);
    }
    return c;
}

vector<int> partitionLabels(string s){
    vector<int> res;

    vector<pair<int, int>> alphaRegion(27, {-1, -1});
    for (int i = 0; i < s.size(); i++) {
        auto a = s[i];
        if (alphaRegion[a - 'a'].first == -1) {
            alphaRegion[a - 'a'].first = alphaRegion[a - 'a'].second = i;
        }
        else {
            alphaRegion[a - 'a'].second = i;
        }
    }

    for (int i = 0; i < alphaRegion.size(); i++) {
        cout << char('a' + i) << ": " << alphaRegion[i].first << " " << alphaRegion[i].second << endl;
    }

    // 去除重复位置
    return deleteRepeat(alphaRegion);
}

int  main(){
    // string s;
    // cin >> s;

    // vector<int> vecLen;
    // for (auto a : vecLen) {
    //     cout << a << endl;
    // }

    string test1 = "ababcbacadefegdehijhklij";
    cout << (partitionLabels(test1) == vector<int>{9, 7, 8});
}
