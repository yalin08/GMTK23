using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Pixelplacement;
public class BossUIScript : Singleton<BossUIScript>
{
    [SerializeField] private TextMeshProUGUI m_textMeshPro;

    
    
     IEnumerator Start()
    {
        m_textMeshPro = gameObject.GetComponent<TextMeshProUGUI>() ?? gameObject.AddComponent<TextMeshProUGUI>();

        int totalVisibleCharacters = m_textMeshPro.text.Length;
        int counter = 0;

            while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            m_textMeshPro.maxVisibleCharacters = visibleCount;
            if (visibleCount >= totalVisibleCharacters)
                yield break;

            counter += 1;
            yield return new WaitForSeconds(0.05f);
        }

    }


    public void Spell()
    {
        
        StartCoroutine(Start());
    }


    public bool stopAnim;



}
