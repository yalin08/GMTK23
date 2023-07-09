using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
public class WandererAnimations : Singleton<WandererAnimations>
{
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public float divideNumber;
    private void Update()
    {
        float f = transform.rotation.y;
        if (WandererStats.Instance.CurrentWeapon != null)
        {
         //   if (f == 180) WandererStats.Instance.CurrentWeapon.transform.rotation = Quaternion.Euler(WandererStats.Instance.CurrentWeapon.transform.rotation.x, 180, WandererStats.Instance.CurrentWeapon.transform.rotation.z);
           // if (f == 00) WandererStats.Instance.CurrentWeapon.transform.rotation = Quaternion.Euler(WandererStats.Instance.CurrentWeapon.transform.rotation.x, 0, WandererStats.Instance.CurrentWeapon.transform.rotation.z);
            
        }

    }


    public void Die()
    {
        animator.SetTrigger("Die");
    }
    public void TurnRight()
    {
        transform.rotation = Quaternion.Euler(0, 180, 0);
        if (WandererStats.Instance.CurrentWeapon != null)
        {
            WandererStats.Instance.CurrentWeapon.sr.flipX = true;
        }

    }
    public void TurnLeft()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);

        if (WandererStats.Instance.CurrentWeapon != null)
        {
            WandererStats.Instance.CurrentWeapon.sr.flipX = false;
        }
       
    }

    public void MoveAnimation()
    {
        animator.SetBool("IsWalking", true);
        animator.speed = WandererStats.Instance.Stats.speed / divideNumber;
    }
    public void IdleAnimation()
    {
        animator.SetBool("IsWalking", false);
        animator.speed = 1;
    }

}
