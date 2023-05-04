using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

public class DataLoader : MonoBehaviour
{
    public TextAsset jsonFile;

    public Graph graphData;
    // Create a list to hold the Node and Edge objects
    public List<Node> nodes = new List<Node>();
    public List<Edge> edges = new List<Edge>();
    //public Graph graphData = new Graph();
    public Graph LoadData()
    {
        // Read the JSON file as a string
        string jsonString = jsonFile.text;        

        // Load the JSON file
        JObject json = JObject.Parse(jsonString);
        //Debug.Log(json["graph"]["nodes"]);

        // Access the "nodes" array
        JArray nodes_json = json["graph"]["nodes"] as JArray;

        // Access the "edges" array
        JArray edges_json = json["graph"]["edges"] as JArray;

        // Iterate over each node
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

            Node node = new Node(id, position, volume);
            //Node node = gameObject.AddComponent<Node>();
            //node.id = id;
            //node.position = position;
            //node.volume = volume;
            nodes.Add(node);
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

            Edge edge = new Edge(id, sourceNodeId, targetNodeId);
            //Edge edge = gameObject.AddComponent<Edge>();
            Node sourceNode = nodes.Find(n => n.id == sourceNodeId);
            Node targetNode = nodes.Find(n => n.id == targetNodeId);

            sourceNode.edges.Add(edge);
            targetNode.edges.Add(edge);

            edges.Add(edge);
        }

        // Construct a GraphData object from the parsed Node and Edge objects
        Graph graphData = new Graph(nodes, edges);

        return graphData;

    }

    void Start()
    {
        Debug.Log("DataLoader.Start() called");
        //LoadData();
        //graphData = gameObject.AddComponent<Graph>();
        //graphData.nodes = nodes;
        //graphData.edges = edges;
        graphData = LoadData();
        Debug.Log($"graphData is created: {graphData}. Num nodes: {graphData.nodes.Count}. Num edges: {graphData.edges.Count}");
    }
}
