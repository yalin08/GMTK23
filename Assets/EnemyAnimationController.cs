using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float divideNumber=2;
    public EnemyStats stats;

    private void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);

    }
    public void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);


    }

    public void MoveAnimation()
    {
        animator.SetBool("IsWalking", true);
        animator.speed = stats.stats.speed / divideNumber;
    }
    public void IdleAnimation()
    {
        animator.SetBool("IsWalking", false);
        animator.speed = 1;
    }
}
