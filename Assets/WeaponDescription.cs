using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Pixelplacement;
public class WeaponDescription : Singleton<WeaponDescription>
{
    public TextMeshProUGUI ItemName, ItemDescription;

    public Image image;

    public GameObject Object;

    public void ShowText(WeaponScript ws)
    {
        Object.SetActive(true);
        ItemName.text = ws.type.name +$"({ws.rarity})";
        ItemName.color = ColorsHolder.Instance.rarityColors[(int)ws.rarity].Color;
        image.sprite = ws.sr.sprite;
        image.material = ws.sr.material;
        image.SetNativeSize();
        ItemDescription.text =ws.type.Description;
    }
    public void CloseText()
    {
        Object.SetActive(false);
    }
}
