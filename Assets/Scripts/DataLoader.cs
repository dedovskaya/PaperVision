using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DataLoader : MonoBehaviour
{
    public TextAsset jsonFile;
    public TextAsset csvFile;
    public GameObject nodePrefab;
    public GameObject edgePrefab;


    //// Create a list to hold the Node and Edge objects
    //private List<Node> nodes = new List<Node>();
    //private List<Edge> edges = new List<Edge>();

    //public Graph graphData = new Graph();
    public void LoadCsvData()
    {
        // Create a parent game object for the graph
        GameObject graphObj = GameObject.Find("MainGraph");
        graphObj.transform.position = new Vector3(0, 0, 0);

        // Set its position to the desired location for the graph
        GameObject nodesObj = new GameObject("Nodes");
        nodesObj.transform.SetParent(graphObj.transform);

        GameObject edgesObj = new GameObject("Edges");
        edgesObj.transform.SetParent(graphObj.transform);

        Graph graphData = gameObject.GetComponent<Graph>();
        string[] lines = csvFile.text.Split('\n');
        string[] header_values = lines[0].Split(',');
        //ArraySegment<string> throat_props = new ArraySegment<string>(values, 0, 27);
        //ArraySegment<string> pore_props = new ArraySegment<string>(values, 27, values.Length);
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            string[] values = line.Split(',');
            if (values.Length > 1)
            {
                if (values[0] != "")
                {
                    // Throat props
                    GameObject edge = Instantiate(edgePrefab, edgesObj.transform);
                    Edge edge_props = edge.GetComponent<Edge>();

                    edge_props.cross_sectional_area = values[0];
                    edge_props.diameter = values[1];
                    edge_props.direct_length = values[2];
                    edge_props.equivalent_diameter = values[3];
                    edge_props.inscribed_diameter = values[4];
                    edge_props.length = values[5];
                    edge_props.perimeter = values[6];
                    edge_props.total_length = values[7];
                    edge_props.volume = values[8];
                    edge_props.all = values[9];
                    edge_props.outer_outer = values[10];
                    edge_props.outer_void = values[11];
                    edge_props.void_outer = values[12];
                    edge_props.void_void = values[13];
                    edge_props.conns0 = values[14];
                    edge_props.conns1 = values[15];
                    edge_props.diffusive_size_factors0 = values[16];
                    edge_props.diffusive_size_factors1 = values[17];
                    edge_props.diffusive_size_factors2 = values[18];
                    edge_props.global_peak0 = values[19];
                    edge_props.global_peak1 = values[20];
                    edge_props.global_peak2 = values[21];
                    edge_props.hydraulic_size_factors0 = values[22];
                    edge_props.hydraulic_size_factors1 = values[23];
                    edge_props.hydraulic_size_factors2 = values[24];
                    edge_props.phases0 = values[25];
                    edge_props.phases1 = values[26];

                    edge.name = edge_props.conns0 + "to" + edge_props.conns1;
                    graphData.edges.Add(edge);
                }
                // Pore props
                if (values[27] != "")
                {
                    GameObject node = Instantiate(nodePrefab, nodesObj.transform);
                    Node node_props = node.GetComponent<Node>();

                    node_props.diameter = float.Parse(values[27]);
                    node_props.equivalent_diameter = values[28];
                    node_props.extended_diameter = values[29];
                    node_props.inscribed_diameter = values[30];
                    node_props.phase = values[31];
                    node_props.region_label = values[32]; //id
                    node_props.region_volume = float.Parse(values[33]);
                    node_props.surface_area = float.Parse(values[34]);
                    node_props.volume = float.Parse(values[35]); //volume
                    node_props.all = values[36];
                    node_props.back = values[37];
                    node_props.front = values[38];
                    node_props.outer_space = values[39];
                    node_props.void_space = values[40];
                    node_props.x = float.Parse(values[41]); //pos
                    node_props.y = float.Parse(values[42]); //pos
                    node_props.z = float.Parse(values[43]); //pos
                    node_props.geometric_centroid0 = values[44];
                    node_props.geometric_centroid1 = values[45];
                    node_props.geometric_centroid2 = values[46];
                    node_props.global_peak0 = values[47];
                    node_props.global_peak1 = values[48];
                    node_props.global_peak2 = values[49];
                    node_props.local_peak0 = values[50];
                    node_props.local_peak1 = values[51];
                    node_props.local_peak2 = values[52];

                    node_props.id = node_props.region_label;
                    Vector3 new_pos = new Vector3(node_props.x, node_props.y, node_props.z);
                    node_props.position = new_pos;

                    // The name is "1.0" so we need to parse int
                    string name = node_props.region_label;
                    string output = name.Replace(".0", "");
                    int name_output = int.Parse(output) - 1;
                    string new_name = name_output.ToString();
                    node.name = new_name;
                    graphData.nodes.Add(node);
                }
            }
        }

        foreach (GameObject edge in graphData.edges)
        {
            Edge edge_props = edge.GetComponent<Edge>();

            GameObject sourceNode = graphData.nodes.Find(n => n.name == edge_props.conns0);
            GameObject targetNode = graphData.nodes.Find(n => n.name == edge_props.conns1);
            edge_props.source_node = sourceNode;
            edge_props.target_node = targetNode;

            // Add edges to nodes
            sourceNode.GetComponent<Node>().edges.Add(edge);
            targetNode.GetComponent<Node>().edges.Add(edge);
        }
    }
        public void LoadJsonData()
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
        GameObject graphObj = GameObject.Find("MainGraph");
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
        //LoadJsonData();
        LoadCsvData();
        Graph graphData = gameObject.GetComponent<Graph>();
        Debug.Log($"graphData is created: {graphData}. Num nodes: {graphData.nodes.Count}. Num edges: {graphData.edges.Count}");
        LoadCsvData();
    }
}
