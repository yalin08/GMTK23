using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{

    public int Price;
    public GameObject outline;   
    public GameObject ItemParticle;
    public SpriteRenderer sr;
    public TMPro.TextMeshPro tmp;

    public void LightUp()
    {
        outline.SetActive(true);
        tmp.text = "" + Price;

    }

    public void LightOff()
    {
        outline.SetActive(false);
        tmp.text = "";

    }
    private void Update()
    {
        if (this == PlayerChestDetector.Instance.SelectedChest && Vector2.Distance(transform.position, PlayerChestDetector.Instance.transform.position)<2)
        {
            LightUp();
        }
        else
        {
            LightOff();
        }
    }


    public void OpenChest()
    {
        if (BoneManager.Instance.Bones < Price)
            return;

        AudioManager.Instance.PlaySound("ChestOpen");
        specialChest.Instance.firstDoor.SetActive(false);
        gameObject.tag = "Untagged";
        Destroy(outline);
        Instantiate(ItemParticle,transform.position,Quaternion.identity);
        Destroy(tmp.gameObject);
        BoneManager.Instance.SpendBones(Price);

        sr.sprite = BoneManager.Instance.OpenChest;
            ;
        Destroy(this);
    }


}
