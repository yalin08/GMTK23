using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LampScript : MonoBehaviour
{
    SpriteRenderer sr;
    Transform player;
    public float offset;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        player = PlayerController.Instance.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y > transform.position.y+offset)
        {
            sr.sortingOrder = 1;

        }
        else
        {
            sr.sortingOrder = -1;
        }
    }
}
