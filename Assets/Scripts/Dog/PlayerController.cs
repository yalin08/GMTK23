using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


public class PlayerController : Singleton<PlayerController>
{


    private Rigidbody2D rb;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

        if (moveX != 0 || moveY != 0)
        {
            PlayerAnimationController.Instance.MoveAnimation();
            CameraFollow.Instance.offset.x = movement.x/3;
            CameraFollow.Instance.offset.y = movement.y/3;
        }
        else
        {
            PlayerAnimationController.Instance.IdleAnimation();
            movement = Vector2.zero;
        }

        
       rb.velocity = movement * PlayerStats.Instance.Stats.speed;
    }
}
