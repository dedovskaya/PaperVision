using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    public List<Node> nodes;
    public List<Edge> edges;

    //public Graph()
    //{

    //}

    public Graph(List<Node> nodes, List<Edge> edges)
    {
        this.nodes = nodes;
        this.edges = edges;
    }
}
