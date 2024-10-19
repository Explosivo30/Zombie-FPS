using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatManager : MonoBehaviour
{
    public static CombatManager Instance;

    public List<GameObject> enemyList = new List<GameObject>();

    public event Action<GameObject> OnEnemyAdded;
    public event Action<GameObject> OnEnemyRemoved;

    int numOfEnemiesInCombat = 0;

    private void Awake()
    {
        if(Instance == null )
        {
            Instance = this;
            OnEnemyAdded += EnemyAdded;
            OnEnemyRemoved += EnemyRemoved;
        }
        else
        {
            Debug.Log("Tienes mas de un CombatManager");
            Destroy(gameObject);
            return;
        }

    }

   

    private void Update()
    {
        
    }


    public void AddEnemy(GameObject enemy)
    {
        if (!enemyList.Contains(enemy))
        {
            enemyList.Add(enemy);
            OnEnemyAdded?.Invoke(enemy);
            Debug.Log($"{enemy.name} ha entrado en combate.");

            
        }
    }

    public void RemoveEnemy(GameObject enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
            OnEnemyRemoved?.Invoke(enemy);
            Debug.Log($"{enemy.name} ha salido del combate.");
        }
    }

    //EVENTS

    private void EnemyAdded(GameObject enemy)
    {
        numOfEnemiesInCombat++;
        Debug.Log(numOfEnemiesInCombat);
    }

    private void EnemyRemoved(GameObject @object)
    {
        numOfEnemiesInCombat--;
        Debug.Log(numOfEnemiesInCombat);
    }

}


