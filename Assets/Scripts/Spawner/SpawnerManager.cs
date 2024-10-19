using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerManager : MonoBehaviour
{
    public static SpawnerManager Instance;

    public List<GameObject> enemiesAlive = new List<GameObject>();

    [SerializeField] int maxEnemies = 50;

    public List<Races> racesList = new List<Races>();

    public GameObject enemy;

    public Transform spawners;

    //TODO
    /*
    Can only be 5 characters per each race
    When they run away from player they need to be respawned in another place of the map
         
     */

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Tienes mas de un SpawnManager");
            Destroy(gameObject);
            return;
        }
    }

    public Races InitEnemy() 
    {
        int randomRace = Random.Range(0, racesList.Count);

        return racesList[randomRace];
    }


    public void SpawnEnemies()
    {
        //Spawn enemies across the map / spawns
        for(int i = 0; i < maxEnemies; i++) 
        {
            // Instantiate Enemy at its position without setting its own transform as parent
            GameObject newEnemy = Instantiate(enemy, enemy.transform.position, Quaternion.identity);

            
            Debug.Log("Instantiated Enemy Position: " + newEnemy.transform.position);
            Debug.Log("Instantiated Enemy Scale: " + newEnemy.transform.localScale);
            Debug.Log("Instantiated Enemy Parent: " + newEnemy.transform.parent);

            // Add the newly instantiated enemy to the list
            //enemiesAlive.Add(newEnemy);


        }

    }



}
