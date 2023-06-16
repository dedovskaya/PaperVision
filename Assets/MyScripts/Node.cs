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
    public string region_label = "";
    public float region_volume = 1f;
    public float surface_area = 1f;
    public float velocity = 0;

    // Edge list
    public List<GameObject> edges = new List<GameObject>();

    //From csv
    public string equivalent_diameter;
    public string extended_diameter;
    public string inscribed_diameter;
    public string all;
    public string back;
    public string front;
    public string outer_space;
    public string void_space;
    public float x;
    public float y;
    public float z;
    public string geometric_centroid0;
    public string geometric_centroid1;
    public string geometric_centroid2;
    public string global_peak0;
    public string global_peak1;
    public string global_peak2;
    public string local_peak0;
    public string local_peak1;
    public string local_peak2;
}
