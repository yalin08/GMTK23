using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBars : MonoBehaviour
{

    public Image DogBar, WandererBar;

  

    // Update is called once per frame
    void Update()
    {

        DogBar.fillAmount = PlayerStats.Instance.Stats.health/PlayerStats.Instance.Stats.maxhealth;
        WandererBar.fillAmount = WandererStats.Instance.Stats.health/ WandererStats.Instance.Stats.maxhealth;
        
    }
}
