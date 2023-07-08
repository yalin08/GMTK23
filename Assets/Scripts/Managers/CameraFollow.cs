using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class CameraFollow : Singleton<CameraFollow>
{


    public Transform target;         
    public float smoothSpeed = 0.5f;  
    public Vector3 offset;          

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset; 
        desiredPosition.z = -10f;
        Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition, smoothSpeed*Time.timeScale);
        transform.position = smoothedPosition;
    }
}
