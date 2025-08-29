#pragma once
#ifndef 并查集模板.H
#define 并查集模板.H
#include <vector>
using namespace std;

class Set
{
public:
    int n = 1005;                           // n根据题目中节点数量而定，一般比节点数量大一点就好
    vector<int> father = vector<int>(n, 0); // C++里的一种数组结构
public:
    // 并查集初始化
    void init();
    
    // 并查集里寻根的过程
    int find(int u);

    // 判断 u 和 v是否找到同一个根
    bool isSame(int u, int v);

    // 将v->u 这条边加入并查集
    void join(int u, int v);
};

#endif
