using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class specialChest : Singleton<specialChest>
{
    public GameObject firstDoor;
    public GameObject Tutorial;
    public void FirstChestOpen()
    {
        firstDoor.SetActive(false);
        Tutorial.SetActive(false);
    }
}
