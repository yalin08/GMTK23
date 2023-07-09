using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using DG.Tweening;

public class WandererStats : Singleton<WandererStats>
{
    public List<WeaponScript> CurrentWeapons;
    public int MaxWeaponInv = 1;
    public WeaponScript CurrentWeapon;
    public Transform HandLocation;
    public Stats Stats;
    public GameObject weaponexplodeparticle;
    public bool CanBeDamaged = true;
    float timer;
    public float canbedamagedtimer;
    float lowAmmo;
    public float knockbackAmount;

    public BoxCollider2D col;
  

    // Start is called before the first frame update
    void Start()
    {
        Stats.health = Stats.maxhealth;
        timer = canbedamagedtimer;
    }



    // Update is called once per frame
    void Update()
    {
        if (CurrentWeapon != null)
        {
            CurrentWeapon.transform.position = HandLocation.position;

            if (CurrentWeapon.BulletCount <= 0)
            {
                CurrentWeapon.fckinExplode();


                if (CurrentWeapons.Count > 0)
                {

                    CurrentWeapon = CurrentWeapons[CurrentWeapons.Count - 1];
                    CurrentWeapon.gameObject.SetActive(true);
                    CurrentWeapons.Remove(CurrentWeapons[CurrentWeapons.Count - 1]);
                    ChangedWeapons();
                    WandererBrain.Instance.ResetShootTimer();
                }
                else NoWeapons();


                GunInInventory.Instance.UpdateWpInventory();
            }
        }

        if (!CanBeDamaged)
        {
            col.isTrigger = true;
            WandererAnimations.Instance.spriteRenderer.color = ColorsHolder.Instance.GetHitColor;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                col.isTrigger = false;
                WandererAnimations.Instance.spriteRenderer.color = Color.white;
                timer = canbedamagedtimer;
                CanBeDamaged = true;
            }
        }
    }
    public void KnockBack(Transform enemy)
    {
        Vector3 direction = (transform.position - enemy.position);

        direction.Normalize();
        transform.DOMove(transform.position + direction * knockbackAmount, 1f);
    }
    public void TakeDamage(float damage)
    {
        Stats.health -= damage;

       


        if (Stats.health <= 0)
        {
            die();
            AudioManager.Instance.PlaySound("HumanDie");
        }
        else if (Stats.health <= Stats.maxhealth * 0.3f)
        {
            HumanTalkStrings.Instance.Talk(6); //low health
            AudioManager.Instance.PlaySound("ManGotHit");
        }
        else
        {
            AudioManager.Instance.PlaySound("ManGotHit");
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (CanBeDamaged)
            if (collision.CompareTag("Enemy"))
            {
                CanBeDamaged = false;
                KnockBack(collision.transform);
                TakeDamage(collision.GetComponent<EnemyStats>().stats.damage);
            }
    }

  

    public void die()
    {
        WandererAnimations.Instance.Die();
        WandererBrain.Instance.enabled = false;
        WandererAnimations.Instance.enabled = false;     
        WandererMove.Instance.enabled = false;
        this.enabled = false;
        HumanTalkStrings.Instance.Talk(5);
    }
    public void ChangedWeapons()
    {
        lowAmmo = CurrentWeapon.BulletCount * 0.3f;
        HumanTalkStrings.Instance.Talk(4);
    }
    public void NoWeapons()
    {
        Debug.Log("noweapons");
        HumanTalkStrings.Instance.Talk(0);
    }
    public void ThankDog()
    {
        HumanTalkStrings.Instance.Talk(1);
    }

    public void NoSpaceButThanks()
    {
        HumanTalkStrings.Instance.Talk(2);
    }
    public void ThisllComeInHandy()
    {
        HumanTalkStrings.Instance.Talk(3);
    }
}


