using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using DG.Tweening;
public class BoneManager : Singleton<BoneManager>
{
    public int Bones;
    public TMPro.TextMeshProUGUI textMesh;

    public GameObject[] possibleWeapons;
    public Sprite OpenChest;
    [Range(0, 100)]
    public int uncommonChance;
    [Range(0, 100)]
    public int RareChance;
    [Range(0, 100)]
    public int EpicChance;
    [Range(0, 100)]
    public int LegendaryChance;
    public Rarity RandomRarity()
    {
        int i = Random.Range(0, 101);
        if (i < uncommonChance)
        {
            return Rarity.uncommon;
        }
        else if (i < RareChance)
        {
            return Rarity.rare;
        }
        else if (i < EpicChance)
        {
            return Rarity.epic;
        }
        else if (i < LegendaryChance)
        {
            return Rarity.legendary;
        }
        else
        {
            return Rarity.common;
        }

    }


    public GameObject RandomWeaponGenerator()
    {

        int i = Random.Range(0, possibleWeapons.Length);

        return possibleWeapons[i];

    }

    private void Start()
    {
        GainBones(0);
        Rarity rarity = RandomRarity();
    }

    public void SpendBones(int bone)
    {
        Bones -= bone;
        if (Bones < 0)
            Bones = 0;
        textMesh.transform.DOKill();
        textMesh.transform.localScale = Vector3.one;
        textMesh.transform.DOScale(1.3f, 0.2f).OnComplete(firstTween);
        textMesh.text = "" + Bones;
    }

    void firstTween()
    {
        textMesh.transform.DOScale(1f, 0.2f);
    }

    public void GainBones(int bone)
    {



        Bones += bone;

        textMesh.transform.DOKill();
        textMesh.transform.localScale = Vector3.one;
        textMesh.transform.DOScale(1.3f, 0.2f).OnComplete(firstTween);

        textMesh.text = "" + Bones;
    }
}
