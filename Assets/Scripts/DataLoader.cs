using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class DataLoader : MonoBehaviour
{
    public TextAsset jsonFile;
    public GameObject nodePrefab;
    public GameObject edgePrefab;


    //// Create a list to hold the Node and Edge objects
    //private List<Node> nodes = new List<Node>();
    //private List<Edge> edges = new List<Edge>();

    //public Graph graphData = new Graph();
    public void LoadData()
    {
        Graph graphData = gameObject.GetComponent<Graph>();
        // Read the JSON file as a string
        string jsonString = jsonFile.text;        

        // Load the JSON file
        JObject json = JObject.Parse(jsonString);
        //Debug.Log(json["graph"]["nodes"]);

        // Access the "nodes" array
        JArray nodes_json = json["graph"]["nodes"] as JArray;

        // Access the "edges" array
        JArray edges_json = json["graph"]["edges"] as JArray;

        // Create a parent game object for the graph
        GameObject graphObj = new GameObject("MainGraph");
        graphObj.transform.position = new Vector3(0, 0, 0);

        // Set its position to the desired location for the graph
        GameObject nodesObj = new GameObject("Nodes");
        nodesObj.transform.SetParent(graphObj.transform);

        GameObject edgesObj = new GameObject("Edges");
        edgesObj.transform.SetParent(graphObj.transform);

        foreach (JObject node_in_json in nodes_json)
        {
            //"id": "78",
            //"metadata": {
            //"node_squared_radius": 4,
            //"node_coordinates": {
            //"x": 20,
            //"y": 100,
            //"z": 5
            //}
            //}
            string id = node_in_json["id"].ToString();

            float node_squared_radius = float.Parse((string)node_in_json["metadata"]["node_squared_radius"]);
            float x = float.Parse((string)node_in_json["metadata"]["node_coordinates"]["x"]);
            float y = float.Parse((string)node_in_json["metadata"]["node_coordinates"]["y"]);
            float z = float.Parse((string)node_in_json["metadata"]["node_coordinates"]["z"]);
            
            Vector3 position = new Vector3(x, y, z);
            float radius = Convert.ToSingle(Math.Sqrt(node_squared_radius));
            float volume = (float)(radius * 4 / 3 * Math.PI * Math.Pow(radius, 3));

            GameObject node = Instantiate(nodePrefab, nodesObj.transform);
            node.name = id;
            Node node_props = node.GetComponent<Node>();
            //Node node_props = nodePrefab.GetComponent<Node>();
            node_props.id = id;
            node_props.position = position;
            node_props.volume = volume;
            graphData.nodes.Add(node);
        }

        // Iterate over each edge
        foreach (JObject edge_in_json in edges_json)
        {
            //"id": "412",
            //"source": "163",
            //"target": "172",
            //"metadata": {
            // "link_length": 16.975024009208838,
            // "link_squared_radius": 3.3799998843075287
            //}

            // Access the "source" and "target" nodes for the current edge
            string id = edge_in_json["id"].ToString();
            string sourceNodeId = (string)edge_in_json["source"];
            string targetNodeId = (string)edge_in_json["target"];

            float edge_length = (float)edge_in_json["metadata"]["link_length"];
            float edge_squared_radius = (float)edge_in_json["metadata"]["link_squared_radius"];

            //Edge edge = gameObject.AddComponent<Edge>();
            GameObject edge = Instantiate(edgePrefab, edgesObj.transform);
            edge.name = sourceNodeId + "to" + targetNodeId;

            Edge edge_props = edge.GetComponent<Edge>();
            GameObject sourceNode = graphData.nodes.Find(n => n.name == sourceNodeId);
            GameObject targetNode = graphData.nodes.Find(n => n.name == targetNodeId);
            edge_props.source_node = sourceNode;
            edge_props.target_node = targetNode;

            // Add edges to nodes
            sourceNode.GetComponent<Node>().edges.Add(edge);
            targetNode.GetComponent<Node>().edges.Add(edge);

            graphData.edges.Add(edge);
        }

    }

    void Start()
    {
        Debug.Log("DataLoader.Start() called");
        LoadData();
        Graph graphData = gameObject.GetComponent<Graph>();
        Debug.Log($"graphData is created: {graphData}. Num nodes: {graphData.nodes.Count}. Num edges: {graphData.edges.Count}");
    }
}
