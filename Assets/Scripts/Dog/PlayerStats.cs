using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using DG.Tweening;


[System.Serializable]
public class Stats
{
    [HideInInspector] public string s;
    public float speed;
    public float health;
    public float maxhealth;
    public float damage;
    public float attackSpeed;
    public float Bulletspeed;  
    public float Bulletlifespan;

    public float shootingRange;
  

}


public class PlayerStats : Singleton<PlayerStats>
{

    public Stats Stats;

    public float ThrowForce;
    public float canbedamagedtimer;
    float timer;
    public float knockbackAmount;
    bool CanBeDamaged=true;
    public BoxCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        Stats.health = Stats.maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

        if (!CanBeDamaged)
        {
            col.isTrigger = true;
            PlayerAnimationController.Instance.spriteRenderer.color = ColorsHolder.Instance.GetHitColor;
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                col.isTrigger = false;
                timer = canbedamagedtimer;
                PlayerAnimationController.Instance.spriteRenderer.color = Color.white;
                CanBeDamaged = true;
            }
        }
    }

    public void KnockBack(Transform enemy)
    {
        Vector3 direction = (transform.position - enemy.position);

        direction.Normalize();
        transform.DOMove(transform.position+direction* knockbackAmount, 0.3f);
    }
    public void TakeDamage(float damage)
    {
        Stats.health -= damage;

       
        AudioManager.Instance.PlaySound("DogGotHit");

        CameraFollow.Instance.ShakeCameraOnHit(1);

        if (Stats.health <= 0)
        {
            die();
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
        Time.timeScale = 0;
        GameOverUI.Instance.LoseUI.SetActive(true);
    }
}


