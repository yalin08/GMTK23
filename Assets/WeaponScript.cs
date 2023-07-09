using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    public WeaponsBase type;
    public Stats stats;

    public Animator animator;
    public Rarity rarity;
    public int BulletCount;
    public int pierce=1;

    public bool onAir;
    // Start is called before the first frame update
    void Start()
    {
        stats = type.stats[(int)rarity];
        pierce = type.pierce;
        BulletCount = type.BulletCount* ((int)rarity+1);
     
        sr.material.SetColor("_ImageOutline", ColorsHolder.Instance.rarityColors[(int)rarity].Color);

    }
    private void OnValidate()
    {
        sr = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
       // animator.GetComponentInChildren<Animator>();
    }

    public void fckinExplode()
    {
        if (!sound) 
        AudioManager.Instance.PlaySound("WeaponExplode");
        GameObject go=  Instantiate(WandererStats.Instance.weaponexplodeparticle, transform.position, transform.rotation);
        Destroy(go, 0.25f);
        Destroy(gameObject);
       
    }
    public void ResetTorqueForce()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
        rb.velocity = Vector2.zero;
        rb.angularVelocity = 0;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (rb.velocity != Vector2.zero || rb.angularVelocity != 0)
        {
            onAir = true;
        }
        else { onAir = false; }

    

    }


    public void ShootBullet()
    {
        AudioManager.Instance.PlaySound("Shoot");

        GameObject bulllet= Instantiate(type.weaponBullet, transform.position, transform.rotation);
        Destroy(bulllet,stats.Bulletlifespan);
        BulletScript bulletScript = bulllet.GetComponent<BulletScript>();
        animator.SetTrigger("Shoot");
        bulletScript.pierce = pierce;
        bulletScript.BulletStats = stats;
        BulletCount--;
       
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Borders"))
        {
            rb.velocity = Vector2.zero;
        }

    }
    bool sound=false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
      

        if (onAir)
            if (collision.CompareTag("Enemy"))
            {
                if (this != WandererStats.Instance.CurrentWeapon)
                {
                    //  Debug.Log((int)(type.stats[(int)rarity].damage));  Debug.Log((int)(type.stats[(int)rarity].damage * type.stats[(int)rarity].attackSpeed * BulletCount));
                    collision.GetComponent<EnemyStats>().TakeDamage((int)(type.stats[(int)rarity].damage * type.stats[(int)rarity].attackSpeed * BulletCount));
                    AudioManager.Instance.PlaySound("WeaponExplodeOnImpact");
                    sound = true;
                    fckinExplode();
                }
               
            }
    }
}
