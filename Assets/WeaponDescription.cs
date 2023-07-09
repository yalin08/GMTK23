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
        Color color1 = ColorsHolder.Instance.rarityColors[(int)ws.rarity].Color;
        Color color = new Color(color1.r,color1.g,color1.b,1);
        ItemName.color = color;
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
