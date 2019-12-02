using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] float secondsBetweenSpawns = 2f;
    [SerializeField] EnemyMovement enemyPrefab;

  
    void Start()
    {
            StartCoroutine(SpawnEnemies());
        
    }

    IEnumerator SpawnEnemies()
    {
        while(true)
        {
            var enemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity) as EnemyMovement;
            enemy.transform.SetParent(gameObject.transform);
            yield return new WaitForSeconds(secondsBetweenSpawns);
        }
        
    }
}
