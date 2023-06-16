using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;
using Unity.XR.CoreUtils;
public class CameraController : MonoBehaviour
{
    public Button finish_button;

    public void TeleportBack()
    {
        float offset = Camera.main.transform.position.y;
        Vector3 start_pos = new Vector3(0, offset, 0);
        //Quaternion start_rot = Quaternion.Euler(0, 90, 0);
        XROrigin xrRig = GameObject.Find("XR Origin").GetComponent<XROrigin>();
        xrRig.MoveCameraToWorldLocation(start_pos);

    }
}
