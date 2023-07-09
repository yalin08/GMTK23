using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


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
    bool CanBeDamaged;

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

    }
}


