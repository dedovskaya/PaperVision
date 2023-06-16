using UnityEngine;
using UnityEngine.UI;

public class ShowPaper : MonoBehaviour
{
    public Toggle toggleElement;

    private void Start()
    {
        // Attach the function to the toggle element's OnValueChanged event
        toggleElement.onValueChanged.AddListener(OnToggleValueChanged);
    }

    public void OnToggleValueChanged(bool isOn)
    {
        // Function to be executed when the toggle value changes
        if (isOn)
        {
            Debug.Log("Toggle is ON");
        }
        else
        {
            Debug.Log("Toggle is OFF");
        }
    }
}
