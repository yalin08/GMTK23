using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;
using TMPro;
using UnityEngine.UI;
public class HumanTalkStrings : Singleton<HumanTalkStrings>
{
    public string[] Strings;

    public TextMeshProUGUI text;
    public GameObject Bubble;

    public void Talk(int i)
    {
        if (Bubble.gameObject.active)
            return;
        Bubble.gameObject.SetActive(true);
        text.text = Strings[i];

        BossUIScript.Instance.Spell();
        float f = Strings[i].Length * 0.13f;

      if (f < 2)
        {
            f = 2f;
        }
            StartCoroutine(DisableSelf(f));

       
    }


    IEnumerator DisableSelf(float f)
    {
        
        yield return new WaitForSeconds(f);
        Bubble.gameObject.SetActive(false);
    }

}
