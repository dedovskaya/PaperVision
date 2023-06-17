using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
//using TreeEditor;
//using UnityEngine.UIElements;

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

    // Materials
    public Material selectedMaterialNodes;
    private Color selectedStartColorEdges;
    private Material selectedMaterialEdges;
    private Color selectedEndColorEdges;
    public Material transparentMaterial;

    private void Start()
    {
        selectedMaterialNodes = Resources.Load<Material>("MyMaterials/Red");
        selectedMaterialEdges = Resources.Load<Material>("MyMaterials/Blue");
        selectedStartColorEdges = Color.green;
        selectedEndColorEdges = Color.blue;

    }
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
                // Assign the new material to the object
                renderer.material.color = Color.red;
                selectedMaterialNodes = renderer.material;
            }  
        }
        else
        {
            Material transparentMaterial = Resources.Load<Material>("MyMaterials/Transparent");
            foreach (GameObject node in graph.nodes)
            {
                Renderer renderer = node.GetComponent<Renderer>();
                // Assign the new material to the object
                renderer.material = transparentMaterial;
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
                selectedStartColorEdges = lineRenderer.startColor;
                
                lineRenderer.endColor = lineColor;
                selectedEndColorEdges = lineRenderer.endColor;
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
            selectedMaterialNodes = renderer.material;
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
            selectedMaterialNodes = renderer.material;
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
            selectedMaterialNodes = renderer.material;
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
            selectedEndColorEdges = lineRenderer.endColor;
            selectedStartColorEdges = lineRenderer.startColor;
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
            selectedEndColorEdges = lineRenderer.endColor;
            selectedStartColorEdges = lineRenderer.startColor;
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
            selectedEndColorEdges = lineRenderer.endColor;
            selectedStartColorEdges = lineRenderer.startColor;
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
    public void CalculateValuesAndSetSliders(Slider slider1, Slider slider2, List<float> data)
    {
        float valMin = FindMinimumFloatList(data);
        Debug.Log(valMin);
        float valMax = FindMaximumFloatList(data);
        Debug.Log(valMax);
        float valMean = FindMeanFloatList(data);
        Debug.Log(valMean);

        // Set minimum and maximum values of the slider to the minimum and maximum values of the data
        slider1.minValue = valMin;
        slider1.maxValue = valMax;

        slider2.minValue = valMin;
        slider2.maxValue = valMax;
        // Sen the value of the slider to minimum
        slider1.value = valMin;
        slider2.value = valMax;

        // Set text of the child component of the slider to the current value of the slider
        slider1.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = slider1.value.ToString();
        slider2.transform.Find("Value Text").GetComponent<TextMeshProUGUI>().text = slider2.value.ToString();

        // Set the text of a child component of the slider to the mean value of the data
        slider2.transform.Find("Max").GetComponent<TextMeshProUGUI>().text = "Maximum: " + valMax.ToString();
        slider2.transform.Find("Min").GetComponent<TextMeshProUGUI>().text = "Minimum: " + valMin.ToString();
        slider2.transform.Find("Mean").GetComponent<TextMeshProUGUI>().text = "Mean: " + valMean.ToString();
    }
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

            CalculateValuesAndSetSliders(panel3_slider1, panel3_slider2, new_data);
            //DeactivateNodesIfOutOfRange(panel3_slider1, panel3_slider2);
        }
        else if (panel3_selectable1.value == 1)
        {
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Node nodeprops = node.GetComponent<Node>();
                new_data.Add(nodeprops.diameter);
            }

            CalculateValuesAndSetSliders(panel3_slider1, panel3_slider2, new_data);
            //DeactivateNodesIfOutOfRange(panel3_slider1, panel3_slider2);

        }
        else if (panel3_selectable1.value == 2)
        {
            foreach (GameObject node in graph.nodes)
            {
                // Get a reference to the object's renderer component
                Node nodeprops = node.GetComponent<Node>();
                new_data.Add(nodeprops.surface_area);
            }

            CalculateValuesAndSetSliders(panel3_slider1, panel3_slider2, new_data);
            //DeactivateNodesIfOutOfRange(panel3_slider1, panel3_slider2);
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
                //node.SetActive(false);
                node.GetComponent<Renderer>().material = transparentMaterial;
            }
            else
            {
                node.GetComponent<Renderer>().material = selectedMaterialNodes;
                //node.SetActive(true);
            }
        }
    }

    ////////////////////////////////////////////////////////////////////// Throat data panel functions
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

                new_data.Add(edgeprops.volume);
            }

            CalculateValuesAndSetSliders(panel4_slider1, panel4_slider2, new_data);
        }
        else if (panel4_selectable1.value == 1)
        {
            foreach (GameObject edge in graph.edges)
            {
                // Get a reference to the object's renderer component
                Edge edgeprops = edge.GetComponent<Edge>();
                new_data.Add(edgeprops.cross_sectional_area);
            }
            CalculateValuesAndSetSliders(panel4_slider1, panel4_slider2, new_data);

        }
        else if (panel4_selectable1.value == 2)
        {
            foreach (GameObject edge in graph.edges)
            {
                // Get a reference to the object's renderer component
                Edge edgeprops = edge.GetComponent<Edge>();
                new_data.Add(edgeprops.diameter);
            }
            CalculateValuesAndSetSliders(panel4_slider1, panel4_slider2, new_data);
        }
        else if (panel4_selectable1.value == 3)
        {
            foreach (GameObject edge in graph.edges)
            {
                // Get a reference to the object's renderer component
                Edge edgeprops = edge.GetComponent<Edge>();
                new_data.Add(edgeprops.length);
            }
            CalculateValuesAndSetSliders(panel4_slider1, panel4_slider2, new_data);
        }
    }
    public void DeactivateEdgesIfOutOfRange()
    {
        foreach (GameObject edge in graph.edges)
        {
            // Get a reference to the object's renderer component
            Edge edgeprops = edge.GetComponent<Edge>();
            if (edgeprops.cross_sectional_area < panel4_slider1.value || edgeprops.cross_sectional_area > panel4_slider2.value)
            {
                // Get a reference to the object's renderer component and set it to transparent material
                edge.GetComponent<Renderer>().material = transparentMaterial;
                //edge.SetActive(false);
            }
            else
            {
                LineRenderer lineRenderer = edge.GetComponent<LineRenderer>();
                lineRenderer.material = selectedMaterialEdges;
                lineRenderer.startColor = selectedStartColorEdges;
                lineRenderer.endColor = selectedEndColorEdges;
                //edge.SetActive(true);
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

    private float ParseFloat(string value)
    {
        float result = 0;
        float.TryParse(value, out result);
        return result;
    }

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

        DeactivateNodesIfOutOfRange();
        DeactivateEdgesIfOutOfRange();
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

