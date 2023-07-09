using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using DG.Tweening;
public class CameraFollow : Singleton<CameraFollow>
{


    public Transform target;         
    public float smoothSpeed = 0.5f;  
    public Vector3 offset;
    public Vector3 offset2;
    public Camera main;
    private void Start()
    {
        Vector3 desiredPosition = target.position + offset;
        desiredPosition.z = -10f;
        main = Camera.main;
        transform.position = desiredPosition;
    }

    public void ShakeCameraOnHit(float strength=3)
    {
        main.DOShakePosition(0.4f,strength);
    }

    public void ShakeCam(Vector2 Direction,float ShakeStrength=1)
    {
      Vector3  offsetTemp = Direction*ShakeStrength;

        DOTween.To(() => offset2.x, x => offset2.x = x, offsetTemp.x, 0.3f); 
        DOTween.To(() => offset2.y, y => offset2.y = y, offsetTemp.y, 0.3f).OnComplete(ResetTween);
   

    }

    void ResetTween()
    {
        DOTween.To(() => offset2.x, x => offset2.x = x, 0, 0.7f); 
        DOTween.To(() => offset2.y, y => offset2.y = y, 0, 0.7f);

       
    }

    private void LateUpdate()
    {
        Vector3 desiredPosition = target.position + offset+ offset2; 
        desiredPosition.z = -10f;
        Vector3 smoothedPosition = Vector3.MoveTowards(transform.position, desiredPosition, smoothSpeed*Time.timeScale);
        transform.position = smoothedPosition;
    }
}
