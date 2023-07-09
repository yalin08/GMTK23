using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class PlayerAnimationController : Singleton<PlayerAnimationController>
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float divideNumber;
    private void Update()
    {
        float f = transform.rotation.y; 
        if (DogPickupGun.Instance.HoldingGun != null)
        {
            if (f == 180) DogPickupGun.Instance.HoldingGun.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (f == 00) DogPickupGun.Instance.HoldingGun.transform.rotation = Quaternion.Euler(0, 180, 0);
            DogPickupGun.Instance.HoldingGun.ResetTorqueForce();
        }
           
    }
    public void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        if (DogPickupGun.Instance.HoldingGun != null)
            DogPickupGun.Instance.HoldingGun.sr.flipX = false;
    }
    public void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (DogPickupGun.Instance.HoldingGun != null)
            DogPickupGun.Instance.HoldingGun.sr.flipX = true;
    }

    public void MoveAnimation()
    {
        animator.SetBool("IsWalking", true);
        animator.speed = PlayerStats.Instance.Stats.speed / divideNumber;
    }
    public void IdleAnimation()
    {
        animator.SetBool("IsWalking", false);
        animator.speed = 1;
    }

}
