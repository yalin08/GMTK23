using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AreaSpawner : MonoBehaviour
{

    public Transform PossibleChestLocationss;
   [HideInInspector] public List<Transform> PossibleChestLocations;


    public GameObject chest;


    public int ChestsToSpawnAmount;

    public int ChestValue;
    private List<int> numbers;


    int CurrentArea = 0;
    public GameObject AreaAfter;
    public GameObject AreaBefore;
    public GameObject[] AreasClosingDoor;
    private void Start()
    {
      
        if (AreaAfter!=null)
        foreach (Transform child in PossibleChestLocationss)
        {
               
            PossibleChestLocations.Add(child.transform);
        }
        GenerateNumbers();
    }
    private void GenerateNumbers()
    {
        numbers = new List<int>();
        int i = ChestsToSpawnAmount;
        if (i > PossibleChestLocations.Count)
        {
    i = PossibleChestLocations.Count;
        }
            

        while (numbers.Count < ChestsToSpawnAmount)
        {
            int randomNumber = Random.Range(1, PossibleChestLocations.Count);

            if (!numbers.Contains(randomNumber))
            {
                numbers.Add(randomNumber);
            }
        }


    }


    public void UnlockNewArea()
    {
        if (AreaAfter != null)
            AreaAfter.SetActive(true);
        if(AreaBefore!=null)
        AreaBefore.SetActive(false);
      


        EnemySpawnManager.Instance.CurrentWave++;
        EnemySpawnManager.Instance.SpawnPoints = PossibleChestLocations.ToArray();


        foreach (GameObject go in AreasClosingDoor)
        {
            go.SetActive(true);
        }

        SpawnChests();
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        UnlockNewArea();
    }


    public void SpawnChests()
    {
        GenerateNumbers();

        foreach (int i in numbers)
        {
          GameObject go=  Instantiate(chest, PossibleChestLocations[i].transform.position,Quaternion.identity);
            go.GetComponent<ChestScript>().Price = ChestValue;


        }
    }

}
