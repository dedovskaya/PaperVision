using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphPosition : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject graph = GameObject.Find("Paper");
        GameObject nodes = GameObject.Find("Nodes");

        //graph.transform.localScale = new Vector3(0.0174136832f, 0.0174136851f, 0.0174136832f);
        //graph.transform.position = new Vector3(0.434870005f, 0.560000002f, 6.33179998f);

        nodes.transform.localScale = new Vector3(0.0160000008f, 0.0160000008f, 0.0160000008f);
        nodes.transform.position = new Vector3(4.96299982f, 0.93599999f, -0.0700000003f);
    }

}
