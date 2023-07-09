using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public Stats stats;
    EnemyBrain brain;
    
    void Start()
    {
        stats.health = stats.maxhealth;
        brain = GetComponent<EnemyBrain>();
    }
    public void TakeDamage(float DamageAmount)
    {
        stats.health -= DamageAmount;
        if (stats.health <= 0)
        {
            FcknDie();
        }
    }
    public void FcknDie()
    {
        Enemies.Instance.enemiesList.Remove(brain);
        BoneManager.Instance.GainBones(Random.Range(5, 11));
        Destroy(gameObject);
    }
}
