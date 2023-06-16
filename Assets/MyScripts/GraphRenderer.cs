using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphRenderer : MonoBehaviour
{
    //public Graph graph_rend = new Graph();
    //public Graph graph = gameObject.GetComponent<Graph>();
    void Start()
    {
        Graph graph = gameObject.GetComponent<Graph>();
        RenderGraph(graph);
    }

    void RenderGraph(Graph graphData)
    {
        // Create GameObjects for each node in the graph and set their positions
        foreach (GameObject node in graphData.nodes)
        {
            Vector3 position = node.GetComponent<Node>().position;
            node.transform.position = position;
        }

        // Create GameObjects for each edge in the graph and set their positions
        foreach (GameObject edge in graphData.edges)
        {
            Edge props = edge.GetComponent<Edge>();

            GameObject source_node = props.source_node;
            GameObject target_node = props.target_node;
            // Get the LineRenderer component of the edge
            LineRenderer lineRenderer = edge.GetComponent<LineRenderer>();

            Vector3 position0 = source_node.GetComponent<Node>().position;
            Vector3 position1 = target_node.GetComponent<Node>().position;
            // Set the positions of the LineRenderer to the center positions of the source and target nodes
            lineRenderer.SetPosition(0, position0);
            lineRenderer.SetPosition(1, position1);
        }
    }
    void Update()
    {
        Graph graph = gameObject.GetComponent<Graph>();

        //// Apply spring forces to nodes
        //foreach (GameObject node in graph.nodes)
        //{
        //    Vector3 position = new Vector3(1, 1, 1);
        //    Vector3 newpos = node.transform.position + position;
        //    node.transform.position = ...
        //}
            foreach (GameObject edge in graph.edges)
        {
            Edge props = edge.GetComponent<Edge>();

            GameObject source_node = props.source_node;
            GameObject target_node = props.target_node;
            Vector3 position0 = source_node.transform.position;
            Vector3 position1 = target_node.transform.position;
            // Set the positions of the LineRenderer to the center positions of the source and target nodes
            LineRenderer lineRenderer = edge.GetComponent<LineRenderer>();
            lineRenderer.SetPosition(0, position0);
            lineRenderer.SetPosition(1, position1);

        }
    }
}
