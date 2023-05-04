using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node
{
    public GameObject nodePrefab;

    public string id;
    public Vector3 position; // pore.coords[0] pore.coords[1] pore.coords[2] + later add centroid ? pore.geometric_centroid[0] pore.geometric_centroid[1] pore.geometric_centroid[2]
    
    public float diameter;
    public float volume;
    public string phase;
    public int region_label;
    public float region_volume;
    public float surface_area;

    // Edge list
    public List<Edge> edges = new List<Edge>();

    public void InitNode()
    {

    }
    public Node(string id, Vector3 position, float volume)
    {
        this.id = id;
        this.position = new Vector3(position.x, position.y, position.z);
        this.volume = volume;
        this.edges = new List<Edge>();
    }

    public Node(Node n)
    {

    }
}
