using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class Enemies : Singleton<Enemies>
{
    public List<EnemyBrain> enemiesList;


   
    private void Awake()
    {
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");

        foreach (GameObject enemyObject in enemyObjects)
        {
            enemiesList.Add(enemyObject.GetComponent<EnemyBrain>());
        }
    }
}
