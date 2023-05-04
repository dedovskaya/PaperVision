using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge
{
    public GameObject edgePrefab;

    public string id;
    public string source_node_id;
    public string target_node_id;
    public bool directed;

    public Edge(string id, string source_node_id, string target_node_id)
    {
        this.id = id;
        this.source_node_id = source_node_id;
        this.target_node_id = target_node_id;        
    }
}
