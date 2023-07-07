using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class PlayerAnimationController : Singleton<PlayerAnimationController>
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float divideNumber;

    public void TurnRight()
    {
        spriteRenderer.flipX = true;
    }
    public void TurnLeft()
    {
        spriteRenderer.flipX = false;
    }

    public void MoveAnimation()
    {
        animator.SetBool("IsWalking", true);
        animator.speed = PlayerStats.Instance.Stats.speed/ divideNumber;
    }
    public void IdleAnimation()
    {
        animator.SetBool("IsWalking", false);
        animator.speed =1;
    }

}
