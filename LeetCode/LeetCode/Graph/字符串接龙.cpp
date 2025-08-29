#include <iostream>
#include <vector>
#include <unordered_set>
#include <unordered_map>
#include <queue>

using namespace std;

int main()
{
    int listLen;
    cin >> listLen;
    unordered_set<string> strSet;

    string beginStr, endStr, str;
    cin >> beginStr >> endStr;
    for (int i = 0; i < listLen; i++)
    {
        cin >> str;
        strSet.insert(str);
    }

    unordered_map<string, int> visitedMap;
    visitedMap.insert(pair<string, int>(beginStr, 1));
    queue<string> strQueue;
    strQueue.push(beginStr);

    while (!strQueue.empty())
    {
        string temp = strQueue.front();
        strQueue.pop();
        int path = visitedMap[temp]; // 路径长度
        for (int i = 0; i < temp.size(); i++)
        {
            string changedTemp = temp;
            for (int j = 0; j < 26; j++)
            {
                changedTemp[i] = j + 'a';
                if (changedTemp == endStr)
                {
                    cout << path + 1 << endl;
                    return 0;
                }

                if (strSet.find(changedTemp) != strSet.end() &&
                    visitedMap.find(changedTemp) == visitedMap.end())
                {
                    strQueue.push(changedTemp);
                    visitedMap.insert({changedTemp, path + 1});
                }
            }
        }
    }

    cout << 0 << endl;
    return 0;
}
