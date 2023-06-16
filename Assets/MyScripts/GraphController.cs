using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphController : MonoBehaviour
{
    public Toggle toggle1;
    public Toggle toggle2;
    public Toggle toggle3;
    public Slider slider1;
    public Slider slider2;
    public string text23 = "Panel 2";
    public bool isRotatingSlow = false;
    public bool isRotatingFast = false;
    public Toggle toggle2_1;
    public Toggle toggle2_2;
    public Graph graph;
    public GameObject paper;

    public void ShowPaper()
    {
        if (toggle1.isOn)
        {
            // Get a reference to the object's renderer component
            Renderer renderer = paper.GetComponent<Renderer>();

            // Check the current material assigned to the object
            Material currentMaterial = renderer.material;

            // Get a reference to the default material you want to assign
            Material defaultMaterial = Resources.Load<Material>("MyMaterials/White");

            renderer.material = defaultMaterial;
        }
        else
        {
            // Get a reference to the object's renderer component
            Renderer renderer = paper.GetComponent<Renderer>();

            // Get a reference to the alternate material you want to assign
            Material alternateMaterial = Resources.Load<Material>("MyMaterials/Transparent");

            renderer.material = alternateMaterial;
        }
    }

    public void ShowNodes() 
    {
        if (toggle2.isOn)
        {
            foreach (GameObject node in graph.nodes)
            {
                Renderer renderer = node.GetComponent<Renderer>();

                // Get a reference to the new material you want to assign
                Material newMaterial = Resources.Load<Material>("MyMaterials/Red");

                // Assign the new material to the object
                renderer.material = newMaterial;
            }
        }
        else
        {
            foreach (GameObject node in graph.nodes)
            {
                Renderer renderer = node.GetComponent<Renderer>();

                // Get a reference to the new material you want to assign
                Material newMaterial = Resources.Load<Material>("MyMaterials/Transparent");

                // Assign the new material to the object
                renderer.material = newMaterial;
            }
        }
    }

    public void ShowEdges()
    {
        if (toggle3.isOn)
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
        }
        else
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
        }
    }

    // Change size nodes + paper
    public void ChangeSize()
    {
        float slider_val = slider1.value;
        // Find the object with the name "Paper" in the scene
        GameObject paperObject = GameObject.Find("Paper");
        GameObject nodes = GameObject.Find("Nodes");

        float initial_scale_paper = 0.02f;
        float initial_scale_nodes = 0.016f;
        nodes.transform.localScale = new Vector3(initial_scale_nodes * slider_val, 
                                                 initial_scale_nodes * slider_val, 
                                                 initial_scale_nodes * slider_val);
        paper.transform.localScale = new Vector3(initial_scale_paper * slider_val,
                                                 initial_scale_paper * slider_val,
                                                 initial_scale_paper * slider_val);
        // Find the parent object in the scene
        GameObject parentObject = GameObject.Find("SliderSizePaperNodes");

        // Find the child object by name
        Transform label = parentObject.transform.Find("Label");
        TextMeshProUGUI textMeshPro = label.GetComponent<TextMeshProUGUI>();
        textMeshPro.text = "Size multiplier: " + slider_val;
    }

    // Change size edges
    public void ChangeSizeEdges()
    {
        float slider_val = slider2.value;
        foreach (GameObject edge in graph.edges)
        {
            LineRenderer lineRenderer = edge.GetComponent<LineRenderer>();
            float initial_width_edge = 0.010f;

            // Set the width of the line
            lineRenderer.startWidth = initial_width_edge * slider_val;
            lineRenderer.endWidth = initial_width_edge * slider_val;
        }
    }
    public void SlowRotate()
    {
        GameObject paper = GameObject.Find("Paper");
        GameObject nodes = GameObject.Find("Nodes");
        nodes.transform.RotateAround(nodes.transform.position, Vector3.up, 10f * Time.deltaTime);
        paper.transform.RotateAround(paper.transform.position, Vector3.up, 10f * Time.deltaTime);
    }

    public void FastRotate()
    {
        GameObject paper = GameObject.Find("Paper");
        GameObject nodes = GameObject.Find("Nodes");
        nodes.transform.RotateAround(nodes.transform.position, Vector3.up, 50f * Time.deltaTime);
        paper.transform.RotateAround(paper.transform.position, Vector3.up, 50f * Time.deltaTime);
    }
    public void ChangeBlue()
    {
        foreach (GameObject node in graph.nodes)
        {
            // Get a reference to the object's renderer component
            Renderer renderer = node.GetComponent<Renderer>();

            // Change the color of the material to red
            renderer.material.color = Color.blue;
        }
    }

    public void ChangeRed()
    {
        foreach (GameObject node in graph.nodes)
        {
            // Get a reference to the object's renderer component
            Renderer renderer = node.GetComponent<Renderer>();

            // Change the color of the material to red
            renderer.material.color = Color.red;
        }
    }

    public void ChangeGreen()
    {
        foreach (GameObject node in graph.nodes)
        {
            // Get a reference to the object's renderer component
            Renderer renderer = node.GetComponent<Renderer>();

            // Change the color of the material to red
            renderer.material.color = Color.green;
        }
    }

    public void ShowBigNodes()
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
    }

/// <summary>
/// ////////////////////////////////////////////////////////////////////////////////////
/// </summary>
// Update is called once per frame
void Update()
    {
        if (toggle2_1.isOn)
        {
            SlowRotate();
        }

        if (toggle2_2.isOn)
        {
            FastRotate();
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
