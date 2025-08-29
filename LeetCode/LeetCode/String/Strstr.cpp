#include <iostream>
#include <string>
#include <vector>

using namespace std;

// Kmp
int Strstr(string& haystack, string& needle)
{
    vector<int> next(needle.size(), 0);
    int len{0}; // 共同前后缀长度
    for(int i = 1; i < needle.size(); i++)
    {
        if(needle[len] == needle[i])
        {
            len++;
            next[i] = len;
        }
        else
        {
            if(len == 0)
            {
                next[i] = 0;
            }
            else
            {
                len = next[len - 1];
                i--;
            }
        }
    }
    // for(int i : next)
    //     cout<< i<< " ";
    // cout << endl;

    int right  = 0;
    for(int i = 0; i < haystack.size(); i++)
    {
        cout<<right<<endl;
        if(haystack[i] == needle[right])
        {
            right++;
        }
        else if(right > 0)
        {
            right = next[right - 1];
            i--;
        }
        if(right == needle.size())
            return i - right + 1;
    }
    return -1;
}

int main()
{
    string s;
    string b;
    while (cin >> s)
    {
        cin >> b;
        cout << Strstr(s, b) << endl;
    }

    return 0;
}
