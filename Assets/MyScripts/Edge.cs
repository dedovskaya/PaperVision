using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edge : MonoBehaviour
{
    public string id;
    public GameObject source_node;
    public GameObject target_node;
    public bool directed;

    // From csv
    public string cross_sectional_area;
    public string diameter;
    public string direct_length;
    public string equivalent_diameter;
    public string inscribed_diameter;
    public string length;
    public string perimeter;
    public string total_length;
    public string volume;
    public string all;
    public string outer_outer;
    public string outer_void;
    public string void_outer;
    public string void_void;
    public string conns0;
    public string conns1;
    public string diffusive_size_factors0;
    public string diffusive_size_factors1;
    public string diffusive_size_factors2;
    public string global_peak0;
    public string global_peak1;
    public string global_peak2;
    public string hydraulic_size_factors0;
    public string hydraulic_size_factors1;
    public string hydraulic_size_factors2;
    public string phases0;
    public string phases1;
}
