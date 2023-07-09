using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WandererCatchGuns : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Weapon")
        {
            WeaponScript ws = collision.GetComponent<WeaponScript>();
            if (ws.onAir)
            {
                ws.ResetTorqueForce();

                AudioManager.Instance.PlaySound("ManPickup");


                if (WandererStats.Instance.CurrentWeapon == null)
                {
                    WandererBrain.Instance.ResetShootTimer();
                    WandererStats.Instance.CurrentWeapon = ws;
                    WandererStats.Instance.ThankDog();
                    GunInInventory.Instance.UpdateWpInventory();
                }
                else
                {
                    if (WandererStats.Instance.CurrentWeapons.Count >= WandererStats.Instance.MaxWeaponInv)
                    {
                        WandererStats.Instance.CurrentWeapons.Add(ws);
                        Destroy(WandererStats.Instance.CurrentWeapons[0].gameObject);
                        WandererStats.Instance.CurrentWeapons.Remove(WandererStats.Instance.CurrentWeapons[0]);
                        WandererStats.Instance.NoSpaceButThanks();
                    }
                    else
                    {
                        WandererStats.Instance.CurrentWeapons.Add(ws);
                        WandererStats.Instance.ThisllComeInHandy();
                    }
                    ws.gameObject.SetActive(false); 
                    GunInInventory.Instance.UpdateWpInventory();
                }
                WandererStats.Instance.CurrentWeapon.ResetTorqueForce();
                //   wa
            }
        }
    }
}
