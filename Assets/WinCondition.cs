using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject WinUI;
    public GameObject WinUICost;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;

            if (WandererStats.Instance.Stats.health > 0)
            {
                WinUI.SetActive(true);
            }
            else
            {
                WinUICost.SetActive(true);
            }

            
           
        }
    }
}
