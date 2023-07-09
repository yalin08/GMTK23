using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParticleScript : MonoBehaviour
{
    public void CreateItem()
    {
        GameObject go = Instantiate(BoneManager.Instance.RandomWeaponGenerator(), transform.position, Quaternion.identity);
        go.GetComponent<WeaponScript>().rarity=BoneManager.Instance.RandomRarity();

    }

    public void destroySelf()
    {
        Destroy(gameObject);
    }
}
