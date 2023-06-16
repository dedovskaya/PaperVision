using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GraphController : MonoBehaviour
{
    // Vizibility panel
    public Toggle panel1_toggle1;
    public Toggle panel1_toggle2;
    public Toggle panel1_toggle3;
    public TMP_Dropdown panel1_dropdown1;
    public TMP_Dropdown panel1_dropdown2;
    public Slider panel1_slider1;
    public Slider panel1_slider2;

    // Animation panel
    //public bool isRotatingSlow = false;
    //public bool isRotatingFast = false;
    public Toggle panel2_toggle1;
    public Toggle panel2_toggle2;
    public Toggle panel2_toggle3;
    public Button panel2_button1;

    // Pore panel
    public TMP_Dropdown panel3_selectable1;
    public Slider panel3_slider1;
    public Slider panel3_slider2;
    private TextMeshProUGUI panel3_max;
    private TextMeshProUGUI panel3_min;
    private TextMeshProUGUI panel3_avg;

    // Throat panel
    public TMP_Dropdown panel4_selectable1;
    public Slider panel4_slider1;
    public Slider panel4_slider2;
    private TextMeshProUGUI panel4_max;
    private TextMeshProUGUI panel4_min;
    private TextMeshProUGUI panel4_avg;

    // Data
    public Graph graph;
    public GameObject paper;

    ////////////////////////////////////////////////////////////////////// Vizibility panel functions 

    public void ShowPaper()
    {
        if (panel1_toggle1.isOn)
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
        if (panel1_toggle2.isOn)
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
        if (panel1_toggle3.isOn)
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

    public void ChangeColorNodes()
    {
        //Change color of nodes depending on the chosen option of Selectable
        if (panel1_dropdown1.value == 0)
        {
            ChangeRed();
        }
        else if (panel1_dropdown1.value == 1)
        {
            ChangeGreen();
        }
        else if (panel1_dropdown1.value == 2)
        {
            ChangeBlue();
        }

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

    public void ChangeColorEdges()
    {
        //Change color of edges depending on the chosen option of Selectable
        if (panel1_dropdown2.value == 0)
        {
            ChangeRedEdges();
        }
        else if (panel1_dropdown2.value == 1)
        {
            ChangeGreenEdges();
        }
        else if (panel1_dropdown2.value == 2)
        {
            ChangeBlueEdges();
        }
    }

    public void ChangeBlueEdges()
    {
        foreach (GameObject edge in graph.edges)
        {
            // Get a reference to the LineRenderer component
            LineRenderer lineRenderer = edge.GetComponent<LineRenderer>();

            // Change the color of the material to red
            lineRenderer.startColor = Color.blue;
            lineRenderer.endColor = Color.blue;
        }
    }

    public void ChangeRedEdges()
    {
        foreach (GameObject edge in graph.edges)
        {
            // Get a reference to the LineRenderer component
            LineRenderer lineRenderer = edge.GetComponent<LineRenderer>();

            // Change the color of the material to red
            lineRenderer.startColor = Color.red;
            lineRenderer.endColor = Color.red;
        }
    }

    public void ChangeGreenEdges()
    {
        foreach (GameObject edge in graph.edges)
        {
            // Get a reference to the LineRenderer component
            LineRenderer lineRenderer = edge.GetComponent<LineRenderer>();

            // Change the color of the material to red
            lineRenderer.startColor = Color.green;
            lineRenderer.endColor = Color.green;
        }
    }

    // Change size nodes + paper
    public void ChangeSize()
    {
        float slider_val = panel1_slider1.value;
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
        float slider_val = panel1_slider2.value;
        foreach (GameObject edge in graph.edges)
        {
            LineRenderer lineRenderer = edge.GetComponent<LineRenderer>();
            float initial_width_edge = 0.010f;

            // Set the width of the line
            lineRenderer.startWidth = initial_width_edge * slider_val;
            lineRenderer.endWidth = initial_width_edge * slider_val;
        }
    }

    ////////////////////////////////////////////////////////////////////// Animation panel functions
    public void RotateX()
    {
        GameObject paper = GameObject.Find("Paper");
        GameObject nodes = GameObject.Find("Nodes");
        nodes.transform.RotateAround(nodes.transform.position, Vector3.right, 10f * Time.deltaTime);
        paper.transform.RotateAround(paper.transform.position, Vector3.right, 10f * Time.deltaTime);
    }

    public void RotateY()
    {
        GameObject paper = GameObject.Find("Paper");
        GameObject nodes = GameObject.Find("Nodes");
        nodes.transform.RotateAround(nodes.transform.position, Vector3.up, 10f * Time.deltaTime);
        paper.transform.RotateAround(paper.transform.position, Vector3.up, 10f * Time.deltaTime);
    }

    public void RotateZ()
    {
        GameObject paper = GameObject.Find("Paper");
        GameObject nodes = GameObject.Find("Nodes");
        nodes.transform.RotateAround(nodes.transform.position, Vector3.forward, 10f * Time.deltaTime);
        paper.transform.RotateAround(paper.transform.position, Vector3.forward, 10f * Time.deltaTime);
    }

    public void ReturnToInitialPosition()
    {
        GameObject paper = GameObject.Find("Paper");
        GameObject nodes = GameObject.Find("Nodes");
        nodes.transform.rotation = Quaternion.Euler(0, 0, 0);
        paper.transform.rotation = Quaternion.Euler(0, -270, 0);
    }

    ////////////////////////////////////////////////////////////////////// Pore data panel functions
    public void VisualizePropertyNodes()
    {
        List<float> new_data = new List<float>();
        if (panel3_selectable1.value == 0)
        {
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Node nodeprops = node.GetComponent<Node>();
                new_data.Add(nodeprops.volume);
            }

            float valMin = FindMinimumFloatList(new_data);
            float valMax = FindMaximumFloatList(new_data);
            float valMean = FindMeanFloatList(new_data);

            // Set minimum and maximum values of the slider to the minimum and maximum values of the data
            panel3_slider1.minValue = valMin;
            panel3_slider1.maxValue = valMax;

            panel3_slider2.minValue = valMin;
            panel3_slider2.maxValue = valMax;
            // Sen the value of the slider to minimum
            panel3_slider1.value = valMin;
            panel3_slider2.value = valMax;

            // Set text of the child component of the slider to the current value of the slider
            panel3_slider1.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel3_slider1.value.ToString();
            panel3_slider2.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel3_slider1.value.ToString();

            // Set the text of a child component of the slider to the mean value of the data
            panel3_slider1.transform.Find("Max").GetComponent<TextMeshProUGUI>().text = valMax.ToString();
            panel3_slider1.transform.Find("Min").GetComponent<TextMeshProUGUI>().text = valMin.ToString();
            panel3_slider1.transform.Find("Mean").GetComponent<TextMeshProUGUI>().text = valMean.ToString();
            DeactivateNodesIfOutOfRange();
        }
        else if (panel3_selectable1.value == 1)
        {
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Node nodeprops = node.GetComponent<Node>();
                new_data.Add(nodeprops.diameter);
            }

            float valMin = FindMinimumFloatList(new_data);
            float valMax = FindMaximumFloatList(new_data);
            float valMean = FindMeanFloatList(new_data);

            // Set minimum and maximum values of the slider to the minimum and maximum values of the data
            panel3_slider1.minValue = valMin;
            panel3_slider1.maxValue = valMax;

            panel3_slider2.minValue = valMin;
            panel3_slider2.maxValue = valMax;
            // Sen the value of the slider to minimum
            panel3_slider1.value = valMin;
            panel3_slider2.value = valMax;

            // Set text of the child component of the slider to the current value of the slider
            panel3_slider1.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel3_slider1.value.ToString();
            panel3_slider2.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel3_slider1.value.ToString();

            // Set the text of a child component of the slider to the mean value of the data
            panel3_slider1.transform.Find("Max").GetComponent<TextMeshProUGUI>().text = valMax.ToString();
            panel3_slider1.transform.Find("Min").GetComponent<TextMeshProUGUI>().text = valMin.ToString();
            panel3_slider1.transform.Find("Mean").GetComponent<TextMeshProUGUI>().text = valMean.ToString();
            DeactivateNodesIfOutOfRange();

        }
        else if (panel3_selectable1.value == 2)
        {
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Node nodeprops = node.GetComponent<Node>();
                new_data.Add(nodeprops.surface_area);
            }

            float valMin = FindMinimumFloatList(new_data);
            float valMax = FindMaximumFloatList(new_data);
            float valMean = FindMeanFloatList(new_data);

            // Set minimum and maximum values of the slider to the minimum and maximum values of the data
            panel3_slider1.minValue = valMin;
            panel3_slider1.maxValue = valMax;

            panel3_slider2.minValue = valMin;
            panel3_slider2.maxValue = valMax;
            // Sen the value of the slider to minimum
            panel3_slider1.value = valMin;
            panel3_slider2.value = valMax;

            // Set text of the child component of the slider to the current value of the slider
            panel3_slider1.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel3_slider1.value.ToString();
            panel3_slider2.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel3_slider1.value.ToString();

            // Set the text of a child component of the slider to the mean value of the data
            panel3_slider1.transform.Find("Max").GetComponent<TextMeshProUGUI>().text = valMax.ToString();
            panel3_slider1.transform.Find("Min").GetComponent<TextMeshProUGUI>().text = valMin.ToString();
            panel3_slider1.transform.Find("Mean").GetComponent<TextMeshProUGUI>().text = valMean.ToString();
            DeactivateNodesIfOutOfRange();
        }
    }

    private float ParseFloat(string value)
    {
        float result = 0;
        float.TryParse(value, out result);
        return result;
    }

    public void VisualizePropertyEdges()
    {
        List<float> new_data = new List<float>();
        if (panel4_selectable1.value == 0)
        {
            foreach (GameObject edge in graph.edges)
            {
                // Get a reference to the object's renderer component
                Edge edgeprops = edge.GetComponent<Edge>();
                // Parse edgeprops.volume to float

                new_data.Add(ParseFloat(edgeprops.volume));
            }

            float valMin = FindMinimumFloatList(new_data);
            float valMax = FindMaximumFloatList(new_data);
            float valMean = FindMeanFloatList(new_data);

            // Set minimum and maximum values of the slider to the minimum and maximum values of the data
            panel4_slider1.minValue = valMin;
            panel4_slider1.maxValue = valMax;

            panel4_slider2.minValue = valMin;
            panel4_slider2.maxValue = valMax;
            // Sen the value of the slider to minimum
            panel4_slider1.value = valMin;
            panel4_slider2.value = valMax;

            // Set text of the child component of the slider to the current value of the slider
            panel4_slider1.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel4_slider1.value.ToString();
            panel4_slider2.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel4_slider1.value.ToString();

            // Set the text of a child component of the slider to the mean value of the data
            panel4_slider1.transform.Find("Max").GetComponent<TextMeshProUGUI>().text = valMax.ToString();
            panel4_slider1.transform.Find("Min").GetComponent<TextMeshProUGUI>().text = valMin.ToString();
            panel4_slider1.transform.Find("Mean").GetComponent<TextMeshProUGUI>().text = valMean.ToString();
            DeactivateEdgesIfOutOfRange();
        }
        else if (panel4_selectable1.value == 1)
        {
            foreach (GameObject edge in graph.edges)
            {
                // Get a reference to the object's renderer component
                Edge edgeprops = edge.GetComponent<Edge>();
                new_data.Add(ParseFloat(edgeprops.cross_sectional_area));
            }
            float valMin = FindMinimumFloatList(new_data);
            float valMax = FindMaximumFloatList(new_data);
            float valMean = FindMeanFloatList(new_data);

            // Set minimum and maximum values of the slider to the minimum and maximum values of the data
            panel4_slider1.minValue = valMin;
            panel4_slider1.maxValue = valMax;

            panel4_slider2.minValue = valMin;
            panel4_slider2.maxValue = valMax;
            // Sen the value of the slider to minimum
            panel4_slider1.value = valMin;
            panel4_slider2.value = valMax;

            // Set text of the child component of the slider to the current value of the slider
            panel4_slider1.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel4_slider1.value.ToString();
            panel4_slider2.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel4_slider1.value.ToString();

            // Set the text of a child component of the slider to the mean value of the data
            panel4_slider1.transform.Find("Max").GetComponent<TextMeshProUGUI>().text = valMax.ToString();
            panel4_slider1.transform.Find("Min").GetComponent<TextMeshProUGUI>().text = valMin.ToString();
            panel4_slider1.transform.Find("Mean").GetComponent<TextMeshProUGUI>().text = valMean.ToString();
            DeactivateEdgesIfOutOfRange();
        }
        else if(panel4_selectable1.value == 2)
        {
            foreach (GameObject edge in graph.edges)
            {
                // Get a reference to the object's renderer component
                Edge edgeprops = edge.GetComponent<Edge>();
                new_data.Add(ParseFloat(edgeprops.diameter));
            }
            float valMin = FindMinimumFloatList(new_data);
            float valMax = FindMaximumFloatList(new_data);
            float valMean = FindMeanFloatList(new_data);

            // Set minimum and maximum values of the slider to the minimum and maximum values of the data
            panel4_slider1.minValue = valMin;
            panel4_slider1.maxValue = valMax;

            panel4_slider2.minValue = valMin;
            panel4_slider2.maxValue = valMax;
            // Sen the value of the slider to minimum
            panel4_slider1.value = valMin;
            panel4_slider2.value = valMax;

            // Set text of the child component of the slider to the current value of the slider
            panel4_slider1.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel4_slider1.value.ToString();
            panel4_slider2.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel4_slider1.value.ToString();

            // Set the text of a child component of the slider to the mean value of the data
            panel4_slider1.transform.Find("Max").GetComponent<TextMeshProUGUI>().text = valMax.ToString();
            panel4_slider1.transform.Find("Min").GetComponent<TextMeshProUGUI>().text = valMin.ToString();
            panel4_slider1.transform.Find("Mean").GetComponent<TextMeshProUGUI>().text = valMean.ToString();
            DeactivateEdgesIfOutOfRange();
        }
        else if (panel4_selectable1.value == 3)
        {
            foreach (GameObject edge in graph.edges)
            {
                // Get a reference to the object's renderer component
                Edge edgeprops = edge.GetComponent<Edge>();
                new_data.Add(ParseFloat(edgeprops.length));
            }
            float valMin = FindMinimumFloatList(new_data);
            float valMax = FindMaximumFloatList(new_data);
            float valMean = FindMeanFloatList(new_data);

            // Set minimum and maximum values of the slider to the minimum and maximum values of the data
            panel4_slider1.minValue = valMin;
            panel4_slider1.maxValue = valMax;

            panel4_slider2.minValue = valMin;
            panel4_slider2.maxValue = valMax;
            // Sen the value of the slider to minimum
            panel4_slider1.value = valMin;
            panel4_slider2.value = valMax;

            // Set text of the child component of the slider to the current value of the slider
            panel4_slider1.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel4_slider1.value.ToString();
            panel4_slider2.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = panel4_slider1.value.ToString();

            // Set the text of a child component of the slider to the mean value of the data
            panel4_slider1.transform.Find("Max").GetComponent<TextMeshProUGUI>().text = valMax.ToString();
            panel4_slider1.transform.Find("Min").GetComponent<TextMeshProUGUI>().text = valMin.ToString();
            panel4_slider1.transform.Find("Mean").GetComponent<TextMeshProUGUI>().text = valMean.ToString();
            DeactivateEdgesIfOutOfRange();
        }
    }

    public void DeactivateEdgesIfOutOfRange()
    {
        foreach (GameObject edge in graph.edges)
        {
            // Get a reference to the object's renderer component
            Edge edgeprops = edge.GetComponent<Edge>();
            if (ParseFloat(edgeprops.cross_sectional_area) < panel4_slider1.value || ParseFloat(edgeprops.cross_sectional_area) > panel4_slider2.value)
            {
                edge.SetActive(false);
            }
            else
            {
                edge.SetActive(true);
            }
        }
    }

    public void DeactivateNodesIfOutOfRange()
    {
        foreach (GameObject node in graph.nodes)
        {
            // Get a reference to the object's renderer component
            Node nodeprops = node.GetComponent<Node>();
            if (nodeprops.diameter < panel3_slider1.value || nodeprops.diameter > panel3_slider2.value)
            {
                node.SetActive(false);
            }
            else
            {
                node.SetActive(true);
            }
        }
    }
    private float FindMinimumFloatList(List<float> floatList)
    {
        float min = 9999999999999;
        foreach (float value in floatList)
        {
            if (value < min)
            {
                min = value;
            }
        }
        return min;
    }

    private float FindMaximumFloatList(List<float> floatList)
    {
        float max = -99999999999999;
        foreach (float value in floatList)
        {
            if (value > max)
            {
                max = value;
            }
        }
        return max;
    }

    private float FindMeanFloatList(List<float> floatList)
    {
        float sum = 0;
        foreach (float value in floatList)
        {
            sum += value;
        }
        return sum / floatList.Count;
    }


    ////////////////////////////////////////////////////////////////////// Throat data panel functions
    // Update is called once per frame
    void Update()
    {
        if (panel2_toggle1.isOn)
        {
            RotateX();
        }

        if (panel2_toggle2.isOn)
        {
            RotateY();
        }

        if (panel2_toggle3.isOn)
        {
            RotateZ();
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
