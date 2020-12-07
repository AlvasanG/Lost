using System.Collections;
using UnityEngine;

public class CameraFacingObject : MonoBehaviour
{
    public Camera m_Camera;
 
    void Start()
    {
        if(m_Camera == null)
            m_Camera = Camera.main;
    }


    //Orient the camera after all movement is completed this frame to avoid jittering
    void LateUpdate()
    {
        transform.LookAt(transform.position + m_Camera.transform.rotation * Vector3.forward,
            m_Camera.transform.rotation * Vector3.up);
    }
}
