using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


public class WandererStats : Singleton<WandererStats>
{
    public List<WeaponScript> CurrentWeapons;
    public int MaxWeaponInv = 1;
    public WeaponScript CurrentWeapon;
    public Transform HandLocation;
    public Stats Stats;
    public GameObject weaponexplodeparticle;
    bool CanBeDamaged;
    float timer;
    public float canbedamagedtimer;
    float lowAmmo;

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

            }
        }

        if (!CanBeDamaged)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = canbedamagedtimer;
                CanBeDamaged = true;
            }
        }
    }
    public void TakeDamage(float damage)
    {
        Stats.health -= damage;
        

       

        if (Stats.health <= 0)
        {
            die();
        }
        else if (Stats.health <= Stats.maxhealth * 0.3f)
        {
            HumanTalkStrings.Instance.Talk(4); //low health
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CanBeDamaged)
            if (collision.CompareTag("Enemy"))
            {
                CanBeDamaged = false;
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


