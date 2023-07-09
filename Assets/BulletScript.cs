using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public Stats BulletStats;
    bool canDamage = true;
    public int pierce=1;
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, transform.position + transform.right, BulletStats.Bulletspeed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (canDamage)
            if (collision.CompareTag("Enemy"))
            {
                pierce--;
                if (pierce <= 0)
                {
                    canDamage = false; Destroy(gameObject);
                }
                
                collision.GetComponent<EnemyStats>().TakeDamage(BulletStats.damage);
               
            }
    }

}
