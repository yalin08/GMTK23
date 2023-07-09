using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pixelplacement;

public class EnemySpawnManager : Singleton<EnemySpawnManager>
{
    public int CurrentWave;
    public GameObject Enemy;

    public Transform[] SpawnPoints;

    public float[] spawnTimer;
    bool gamestarted = false;
    private void Update()
    {
        if (!gamestarted)
            if (CurrentWave >= 1)
            {
                StartCoroutine(startWaves());
                gamestarted = true;
            }
    }

    IEnumerator startWaves()
    {
        yield return new WaitForSeconds(spawnTimer[CurrentWave]);

        GameObject go = Instantiate(Enemy, SpawnPoints[Random.Range(0, SpawnPoints.Length)].transform.position, Quaternion.identity);

        EnemyBrain eb = go.GetComponent<EnemyBrain>();


        eb.stats.stats.damage *= 1 + ((float)CurrentWave / 5);
        eb.stats.stats.health *= 1 + ((float)CurrentWave / 5);

     
        StartCoroutine(startWaves());
    }


}
