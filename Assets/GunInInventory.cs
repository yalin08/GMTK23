using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunInInventory : MonoBehaviour
{

    public List<Image> WeaponUIList;

    private void Update()
    {
        if (WandererStats.Instance.CurrentWeapon != null)
        {
            WeaponUIList[WeaponUIList.Count - 1].sprite = WandererStats.Instance.CurrentWeapon.sr.sprite;
            WeaponUIList[WeaponUIList.Count - 1].material = WandererStats.Instance.CurrentWeapon.sr.material;
            WeaponUIList[WeaponUIList.Count - 1].SetNativeSize();


            WeaponUIList[WeaponUIList.Count - 1].color = Color.white;
        }
        else
        {
            WeaponUIList[WeaponUIList.Count - 1].sprite = null;
            WeaponUIList[WeaponUIList.Count - 1].color = new Color(0, 0, 0, 0);
        }

        for (int i = 0; i < WeaponUIList.Count - 1; i++)
        {
            if (WandererStats.Instance.CurrentWeapons.Count > i)
            {
                if (WandererStats.Instance.CurrentWeapons[i] != null)
                {
                    WeaponUIList[i].sprite = WandererStats.Instance.CurrentWeapons[i].sr.sprite;
                    WeaponUIList[i].material = WandererStats.Instance.CurrentWeapons[i].sr.material;
                    WeaponUIList[i].color = Color.white;
                    WeaponUIList[i].SetNativeSize();
                }
                else
                {
                    WeaponUIList[i].color = new Color(0,0,0,0);

                }
            }
            else
            {
                WeaponUIList[i].color = new Color(0, 0, 0, 0);

            }



        }
    }
}
