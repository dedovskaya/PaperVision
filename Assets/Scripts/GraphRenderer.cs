using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphRenderer : MonoBehaviour
{
    //public EdgeProps edgeProps;
    public GameObject nodePrefab;
    public GameObject edgePrefab;
    public DataLoader dataLoader;

    public List<GameObject> nodesGameObjectList;
    private List<GameObject> edgesGameObjectList;

    void Start()
    {
        nodesGameObjectList = new List<GameObject>();
        edgesGameObjectList = new List<GameObject>();
        RenderGraph(dataLoader.LoadData());
    }

    void RenderGraph(Graph graphData)
    {
        // Create a parent game object for the graph
        GameObject graphObj = new GameObject("Graph");
        // Set its position to the desired location for the graph
        GameObject nodesObj = new GameObject("Nodes");
        nodesObj.transform.SetParent(graphObj.transform, false);
        graphObj.transform.position = new Vector3(0, 0, 0);
        // Create GameObjects for each node in the graph and set their positions
        foreach (Node nodeData in graphData.nodes)
        {
            GameObject nodeObj = Instantiate(nodePrefab, nodeData.position, Quaternion.identity, nodesObj.transform);
            nodeObj.name = nodeData.id;
            //nodeObj.transform.position = nodeData.position;
            nodesGameObjectList.Add(nodeObj);
        }

        GameObject edgesObj = new GameObject("Edges");
        edgesObj.transform.SetParent(graphObj.transform, false);
        // Create GameObjects for each edge in the graph and set their positions
        foreach (Edge edgeData in graphData.edges)
        {
            GameObject edgeObj = Instantiate(edgePrefab, edgesObj.transform);
            EdgeProps edgeProps = edgeObj.AddComponent(typeof(EdgeProps)) as EdgeProps;
            edgeObj.name = edgeData.source_node_id + " to " + edgeData.target_node_id;
            // Get the LineRenderer component of the edge
            LineRenderer lineRenderer = edgeObj.GetComponent<LineRenderer>();

            // Set the positions of the LineRenderer to the center positions of the source and target nodes
            lineRenderer.SetPosition(0, nodesGameObjectList.Find(n => n.name == edgeData.source_node_id).transform.position);
            lineRenderer.SetPosition(1, nodesGameObjectList.Find(n => n.name == edgeData.target_node_id).transform.position);

            edgesGameObjectList.Add(edgeObj);
        }
    }
    void Update()
    {

        //// Apply spring forces to nodes
        //foreach (GameObject nodeObj in nodesGameObjectList)
        //{
        //    Node node = dataLoader.graphData.nodes.Find(n => n.id == nodeObj.name);

        //    foreach (Edge edge in node.edges)
        //    {
        //        Node otherNode = (edge.source_node_id == node.id) ? edge.target_node_id : edge.source_node_id;
        //        //Node otherNode = (edge.source == node) ? edge.target : edge.source;
        //        //Vector3 direction = otherNode.position - node.position;
        //        //float distance = direction.magnitude;
        //        //float displacement = distance - graphController.springLength;
        //        //float springForce = displacement * graphController.springStiffness;
        //        //force += direction.normalized * springForce;

        //        // Update edge position
        //        GameObject edgeObj = edgesGameObjectList.Find(e => e.name == edge.source_node_id + " to " + edge.target_node_id);
        //        LineRenderer lineRenderer = edgeObj.GetComponent<LineRenderer>();
        //        lineRenderer.SetPosition(0, nodeObj.transform.position);
        //        lineRenderer.SetPosition(1, nodesGameObjectList.Find(n => n.name == otherNode.id).transform.position);

        //    }
        //}
    }
}
