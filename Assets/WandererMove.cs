using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class WandererMove : Singleton<WandererMove>
{

    Rigidbody2D rb;
    Transform companionPoint, companionRunPoint;
    public float stopFollowDistance;
    public float StartFollowDistance;

    public bool Stop;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        companionPoint = PlayerController.Instance.CompanionPoint;
        companionRunPoint= PlayerController.Instance.CompanionRunPoint;
    }
    void StopMove()
    {
        Stop = true;
        rb.velocity = Vector2.zero; 

    }
    void MoveTo(Transform point)
    {
        Vector2 direction = (point.position - transform.position);
      
        direction.Normalize();
        //  rb.AddForce(direction* WandererStats.Instance.Stats.speed);

        rb.velocity = direction * PlayerStats.Instance.Stats.speed;
        if (rb.velocity.x > 0)
            WandererAnimations.Instance.TurnLeft();
        if (rb.velocity.x < 0)
            WandererAnimations.Instance.TurnRight();
    }

    void Update()
    {
        float DistanceToMovePoint = Vector2.Distance(transform.position, companionPoint.position);
         float DistanceToDog = Vector2.Distance(transform.position,PlayerController.Instance.transform.position);
        if (WandererStats.Instance.CanBeDamaged)
        {
            if (DistanceToDog < StartFollowDistance)
            {
                if (DistanceToMovePoint > stopFollowDistance)
                {
                    if (!Stop)
                        MoveTo(companionPoint.transform);

                }
                else
                    StopMove();
            }
            else
            {
                float DistanceToRunPoint = Vector2.Distance(transform.position, companionRunPoint.position);
                if (DistanceToRunPoint > stopFollowDistance)
                    MoveTo(companionRunPoint.transform);
                else
                    StopMove();
            }
        }
        else
        {
            if (WandererBrain.Instance.closestEnemy != null)
            {
                Vector2 direction = ( transform.position- WandererBrain.Instance.closestEnemy.transform.position);
                
                direction.Normalize();
                //  rb.AddForce(direction* WandererStats.Instance.Stats.speed);

                rb.velocity = direction * PlayerStats.Instance.Stats.speed;
                if (rb.velocity.x > 0)
                    WandererAnimations.Instance.TurnLeft();
                if (rb.velocity.x < 0)
                    WandererAnimations.Instance.TurnRight();
            }
            else
            {
                MoveTo(companionRunPoint);


            }
        }


        if (DistanceToDog > 20)
        {
            transform.position = companionRunPoint.position;

        }

        if (rb.velocity == Vector2.zero)
        {
            WandererAnimations.Instance.IdleAnimation();
        }
        else
        {
             WandererAnimations.Instance.MoveAnimation();
        }


        //  transform.position = Vector2.MoveTowards(transform.position, companionPoint.position, WandererStats.Instance.Stats.speed); 
    }
}
