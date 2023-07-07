using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public GameObject FollowObject;
    public float followSpeed;

    private void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, FollowObject.transform.position,PlayerStats.Instance.Stats.speed*0.95f);
    }
}
