#include <iostream>
#include <vector>

#include "并查集模板.h"

using namespace std;



int main()
{
    Set s;
    int n, m;
    cin >> n >> m;
    for(int i = 0; i < m; i++)
    {
        int a,b;
        cin >> a >> b;
        s.join(a,b);
    }
}
