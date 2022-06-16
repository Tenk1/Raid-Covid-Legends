using Invector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
 public Camera rearCamera;
 public Camera driverCamera;
 
 
    void Start()
    {
        rearCamera.enabled = false;
        driverCamera.enabled = true;
    }

    void Update()
    {
        if (Input.GetButtonDown("CameraSwitch"))
        {
            driverCamera.enabled = !driverCamera.enabled;
            rearCamera.enabled = !rearCamera.enabled;
        }
        if (Input.GetButtonUp("CameraSwitch"))
        {
            rearCamera.enabled = !rearCamera.enabled;
            driverCamera.enabled = !driverCamera.enabled;
            
        }
    }
}
