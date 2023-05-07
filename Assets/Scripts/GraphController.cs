using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphController : MonoBehaviour
{
    public bool hidePaper = false;
    public bool showPaper = false;

    public bool hideNodes = false;
    public bool showNodes = false;

    public bool hideEdges = false;
    public bool showEdges = false;

    public bool slowRotate = false;
    public bool fastRotate = false;

    public bool changeNodeColorBlue = false;
    public bool changeNodeColorRed = false;
    public bool changeNodeColorGreen = false;

    public bool changeNodeColorFilter = false;
    public bool createForceGraph = false;

    //Property based filters
    public float volumeTH = 200;
    public bool showBigNodes = false;

    // Update is called once per frame
    void Update()
    {
        Graph graph = gameObject.GetComponent<Graph>();

        if (hidePaper)
        {
            // Find the object with the name "Paper" in the scene
            GameObject paperObject = GameObject.Find("Paper");

            // Get a reference to the object's renderer component
            Renderer renderer = paperObject.GetComponent<Renderer>();

            // Get a reference to the new material you want to assign
            Material newMaterial = Resources.Load<Material>("Materials/TransparentMat");

            // Assign the new material to the object
            renderer.material = newMaterial;

            hidePaper = false;
        }

        if (showPaper)
        {
            // Find the object with the name "Paper" in the scene
            GameObject paperObject = GameObject.Find("Paper");

            // Get a reference to the object's renderer component
            Renderer renderer = paperObject.GetComponent<Renderer>();

            // Get a reference to the new material you want to assign
            Material newMaterial = Resources.Load<Material>("Materials/NormalMat"); 
            renderer.material = newMaterial;
            showPaper = false;
        }

        if (hideNodes)
        {
            foreach (GameObject node in graph.nodes)
            {
                Renderer renderer = node.GetComponent<Renderer>();

                // Get a reference to the new material you want to assign
                Material newMaterial = Resources.Load<Material>("Materials/TransparentMat");

                // Assign the new material to the object
                renderer.material = newMaterial;
            }
            hideNodes = false;
        }

        if (showNodes)
        {
            foreach (GameObject node in graph.nodes)
            {
                Renderer renderer = node.GetComponent<Renderer>();

                // Get a reference to the new material you want to assign
                Material newMaterial = Resources.Load<Material>("Materials/RedMat");

                // Assign the new material to the object
                renderer.material = newMaterial;
            }
            showNodes = false;
        }

        if (hideEdges)
        {
            foreach (GameObject egde in graph.edges)
            {
                // Get a reference to the LineRenderer component
                LineRenderer lineRenderer = egde.GetComponent<LineRenderer>();

                // Get the current color of the LineRenderer
                Color lineColor = lineRenderer.startColor;

                // Set the alpha value to 0
                lineColor.a = 0;

                // Update the LineRenderer's color with the new alpha value
                lineRenderer.startColor = lineColor;
                lineRenderer.endColor = lineColor;
            }
            hideEdges = false;
        }

        if (showEdges)
        {
            foreach (GameObject egde in graph.edges)
            {
                // Get a reference to the LineRenderer component
                LineRenderer lineRenderer = egde.GetComponent<LineRenderer>();

                // Get the current color of the LineRenderer
                Color lineColor = lineRenderer.startColor;

                // Set the alpha value to 0
                lineColor.a = 1;

                // Update the LineRenderer's color with the new alpha value
                lineRenderer.startColor = lineColor;
                lineRenderer.endColor = lineColor;
            }
            showEdges = false;
        }

        if (slowRotate)
        {
            // Find the object with the name "Paper" in the scene
            GameObject paperObject = GameObject.Find("Paper");
            GameObject nodes = GameObject.Find("Nodes");
            //// Rotate the object around the y-axis
            //mainGraph.transform.Rotate(0, 10f * Time.deltaTime, 0);
            //paperObject.transform.Rotate(0, 10f * Time.deltaTime, 0);
            nodes.transform.RotateAround(nodes.transform.position, Vector3.up, 10f * Time.deltaTime);
            paperObject.transform.RotateAround(paperObject.transform.position, Vector3.up, 10f * Time.deltaTime);

        }
        if (fastRotate)
        {
            // Find the object with the name "Paper" in the scene
            GameObject paperObject = GameObject.Find("Paper");
            GameObject mainGraph = GameObject.Find("Nodes");
            // Rotate the object around the y-axis
            mainGraph.transform.Rotate(0, 50f * Time.deltaTime, 0);
            paperObject.transform.Rotate(0, 50f * Time.deltaTime, 0);
        }
        if (changeNodeColorBlue)
        {
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Renderer renderer = node.GetComponent<Renderer>();

                // Change the color of the material to red
                renderer.material.color = Color.blue;
            }
            changeNodeColorBlue = false;
        }

        if (changeNodeColorRed)
        {
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Renderer renderer = node.GetComponent<Renderer>();

                // Change the color of the material to red
                renderer.material.color = Color.red;
            }
            changeNodeColorRed = false;
        }

        if (changeNodeColorGreen)
        {
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Renderer renderer = node.GetComponent<Renderer>();

                // Change the color of the material to red
                renderer.material.color = Color.green;
            }
            changeNodeColorGreen = false;
        }

        if (changeNodeColorFilter)
        {

        }

        if (showBigNodes) 
        {
            Vector3 scale = new Vector3(5, 5, 5);
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Node nodeprops = node.GetComponent<Node>();

                if (nodeprops.volume > 200)
                {
                    node.transform.localScale = scale;
                }

            }
            changeNodeColorGreen = false;
        }

        if (showBigNodes)
        {
            Vector3 scaleNormal = new Vector3(2, 2, 2);
            Vector3 scale = new Vector3(5, 5, 5);
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Node nodeprops = node.GetComponent<Node>();

                if (nodeprops.volume > volumeTH)
                {
                    node.transform.localScale = scale;
                }
                else
                {
                    node.transform.localScale = scaleNormal;
                }
            }
        }

        //if (createForceGraph)
        //{
        //    float springLength = 20;
        //    float springStiffness = 2;
        //    float nodeRepulsion = 10;
        //    float damping = 0.8f;
        //    // Apply spring forces to nodes
        //    foreach (GameObject node in graph.nodes)
        //    {
        //        Node node_props = node.GetComponent<Node>();
        //        Vector3 force = Vector3.zero;

        //        node.transform.position = Vector3(x, 0, z);

        //        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //        // Calculate spring forces between connected nodes
        //        foreach (GameObject edge in node_props.edges)
        //        {
        //            Edge edge_props = edge.GetComponent<Edge>();
        //            GameObject otherNode = (edge_props.source_node == node) ? edge_props.target_node : edge_props.source_node;
        //            Vector3 direction = otherNode.transform.position - node.transform.position;
        //            float distance = direction.magnitude;
        //            float displacement = distance - springLength;
        //            float springForce = displacement * springStiffness;
        //            force += direction.normalized * springForce;

        //            // Update edge position
        //            GameObject edgeObj = graph.edges.Find(e => e.name == edge.source.id + " to " + edge.target.id);
        //            LineRenderer lineRenderer = edgeObj.GetComponent<LineRenderer>();
        //            lineRenderer.SetPosition(0, nodeObj.transform.position);
        //            lineRenderer.SetPosition(1, nodes.Find(n => n.name == otherNode.id).transform.position);

        //        }

        //        ////////////////////////////////////////////////////////////////////////////////////////////////////
        //        // Calculate repulsion forces between all nodes
        //        foreach (GameObject otherNode in graph.nodes)
        //        {
        //            node_props = node.GetComponent<Node>();
        //            if (otherNode == node) continue;
        //            Vector3 direction = otherNode.transform.position - node.transform.position;
        //            float distance = direction.magnitude;
        //            float repulsionForce = nodeRepulsion / (distance * distance);
        //            force -= direction.normalized * repulsionForce;
        //        }

        //        // Apply damping to current velocity
        //        node.velocity *= graphController.damping;

        //        // Apply force to current velocity
        //        node.velocity += force * Time.fixedDeltaTime;

        //        if (!graphController.freezeGraph)
        //        {
        //            nodeObj.transform.position = node.position;
        //            node.position += node.velocity * Time.fixedDeltaTime;
        //            textMesh.transform.position = node.position;
        //        }
        //    }
        //}
    }
}
