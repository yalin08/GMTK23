using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public enum Rarity
{
    common, uncommon, rare, epic, legendary
}

[CreateAssetMenu(menuName = "Weapons/Weapon")]
public class WeaponsBase : ScriptableObject
{
    
    public GameObject weaponPrefab;
    public GameObject weaponBullet;
    public int BulletCount;
    public int pierce=1;
    public Stats[] stats=new Stats[(Enum.GetValues(typeof(Rarity)).Length)];
    private void OnValidate()
    {
        for (int i=0; i < (Enum.GetValues(typeof(Rarity)).Length);i++)
        {
            Rarity r = (Rarity)i;
            stats[i].s = ""+r;
        }

   
    }

}
