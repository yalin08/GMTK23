using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


public class PlayerController : Singleton<PlayerController>
{


    public Rigidbody2D rb;
    public Transform CompanionPoint;
    public Transform CompanionRunPoint;

    public float ChangePositionTimer;

    float timer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        timer = ChangePositionTimer;
    }
    void ChangeCompPos()
    {
        timer = ChangePositionTimer*Random.Range(0.8f,1.2f);
        WandererMove.Instance.Stop = false;
        Vector2 vector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));

        CompanionPoint.position = transform.position - (Vector3)vector.normalized * Random.Range(0.5f, WandererMove.Instance.StartFollowDistance);
    }
    void Update()
    {
    
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector2 movement = new Vector2(moveX, moveY);

     
        if (movement.magnitude > 1f)
        {
            movement = movement.normalized;
         
        }

       
       
        if (moveX > 0)
        {
            PlayerAnimationController.Instance.TurnRight();
        }
        else if (moveX < 0)
        {
            PlayerAnimationController.Instance.TurnLeft();
        }



        if (Mathf.Abs(moveX) > 0.2f || Mathf.Abs(moveY) > 0.2f)
        {
            CompanionRunPoint.position = transform.position - (Vector3)movement;
        }
        else
        {

            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ChangeCompPos();
            }
        }


        if (moveX != 0 || moveY != 0)
        {
            PlayerAnimationController.Instance.MoveAnimation();
            CameraFollow.Instance.offset.x = Mathf.Lerp(CameraFollow.Instance.offset.x,movement.x,Time.deltaTime)  ;
            CameraFollow.Instance.offset.y = Mathf.Lerp(CameraFollow.Instance.offset.y, movement.y, Time.deltaTime);
           
        }
        else
        {
           


            PlayerAnimationController.Instance.IdleAnimation();
            CameraFollow.Instance.offset.x = Mathf.Lerp(CameraFollow.Instance.offset.x, 0, Time.deltaTime/2);
            CameraFollow.Instance.offset.y = Mathf.Lerp(CameraFollow.Instance.offset.y, 0, Time.deltaTime/2);
            movement = Vector2.zero;
        }

        
       rb.velocity = movement * PlayerStats.Instance.Stats.speed;
    }
}
