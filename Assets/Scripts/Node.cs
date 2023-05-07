using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour
{
    public string id;
    public Vector3 position; // pore.coords[0] pore.coords[1] pore.coords[2] + later add centroid ? pore.geometric_centroid[0] pore.geometric_centroid[1] pore.geometric_centroid[2]
    
    public float diameter = 1f;
    public float volume = 1f;
    public string phase = "1";
    public int region_label = 1;
    public float region_volume = 1f;
    public float surface_area = 1f;
    public float velocity = 0;

    // Edge list
    public List<GameObject> edges = new List<GameObject>();

    //public Node(string id, Vector3 position, float diameter, float volume, List<Edge> edges)
    //{
    //    this.id = id;
    //    this.position = position;
    //    this.diameter = diameter;
    //    this.volume = volume;
    //    this.edges = edges;
    //}
}
