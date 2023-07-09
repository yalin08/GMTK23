using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

[System.Serializable]
public class RarityColors
{
    [HideInInspector]public string name;
    public Color Color;
}

public class ColorsHolder : Singleton<ColorsHolder>
{
    public RarityColors[] rarityColors=new RarityColors[(Enum.GetValues(typeof(Rarity)).Length)];
     private void OnValidate()
    {
        for (int i=0; i < (rarityColors.Length);i++)
        {
            Rarity r = (Rarity)i;
            rarityColors[i].name = ""+r;
        }

   
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
