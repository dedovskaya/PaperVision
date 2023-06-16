using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TeleportToStart : MonoBehaviour
{
    Button finish_button;
    // Start is called before the first frame update
    //private void Update()
    //{
    //    finish_button.onClick(TeleportBack());
    //}

    public void TeleportBack()
    {
        Vector3 start_pos = new Vector3(0, 0, 0);

        Quaternion start_rot = new Quaternion(0, 90, 0, 0);
        gameObject.transform.position = start_pos;
        gameObject.transform.rotation = start_rot;
    }
}
