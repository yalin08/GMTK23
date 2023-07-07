using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;


[System.Serializable]
public class Stats
{
    public float speed;
    public float health;
    public float maxhealth;
    public float damage;
    public float attackSpeed;

}


public class PlayerStats : Singleton<PlayerStats>
{

    public Stats Stats;

    // Start is called before the first frame update
    void Start()
    {
        Stats.health = Stats.maxhealth;
    }

    // Update is called once per frame
    void Update()
    {

    }
}


