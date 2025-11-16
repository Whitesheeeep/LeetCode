#pragma once
#ifndef GRAPHALGORITHM_H
#define GRAPHALGORITHM_H
#include <vector>
using namespace std;


class Edge
{

public:
    int to;
    int weight;
    Edge(int t, int w) : to(t), weight(w) {}
};

class Algorithm
{

    void Bellman_ford(const vector<vector<int>> &grid, vector<int> &minDist);
    void SPFA(const vector<vector<Edge>> &graph, vector<int> &minDist);
    void Floyd();
};

#endif
