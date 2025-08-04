#include <iostream>
#include <string>
#include <algorithm>
#include <ranges>

using namespace std;

class Solution
{
public:
    string reverseWords(string s)
    {
        int slow = 0;
        for(int i = 0; i < s.size(); i++)
        {
            if(slow != 0 && s[i] != ' ') s[slow++] = ' ';
            while(i < s.size() && s[i] != ' ')
                s[slow++] = s[i++];
        }
        s.resize(slow);
        // 先整个翻过来
        std::reverse(s.begin(), s.end());
        auto start = s.begin();
        for (auto i = s.begin(); i <= s.end(); i++)
        {
            if (i == s.end() || *i == ' ')
            {
                reverse(start, i);
                start = i + 1;
            }
        }
        return s;
    }
};

int main()
{
    string s;
    Solution sol;
    while (true)
    {
        getline(cin, s);
        cout << sol.reverseWords(s) << endl;
    }
}
