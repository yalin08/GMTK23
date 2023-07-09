using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class PlayerChestDetector : Singleton<PlayerChestDetector>
{
    public ChestScript SelectedChest;
    public List<ChestScript> allChest;

    private void Update()
    {
        if (SelectedChest != null)
        {
            if (Vector2.Distance(SelectedChest.transform.position, transform.position) < 1)
            {
                if (Input.GetButtonDown("Fire2"))
                {


                    SelectedChest.OpenChest();



                }
            }
        }

        else
        {
            SelectedChest = null;
        }



    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        if (collision.CompareTag("Chest"))
        {
            SelectedChest = collision.GetComponent<ChestScript>();


        }
    }



}
