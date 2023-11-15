using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public class EnemyPoolManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    [Range(0,10)]
    public int poolSize = 5;
    GameObject newEnemy;
    List<Enemy> enemyPool = new List<Enemy>();
    [Range(0.1f,5f)]
    public float spawnInterval =1f;
    public Transform[] spawnPoints; 

    private void Start()
    {
        enemyPool = GameObject.FindObjectsOfType<Enemy>().ToList();
      

        StartCoroutine(SpawnEnemiesRandomly());
    }

    private IEnumerator SpawnEnemiesRandomly()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

           
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            
            SpawnEnemy(spawnPoint.position);
        }
    }
    public Enemy SpawnEnemy(Vector3 spawnPosition)
    {
        foreach (Enemy enemy in enemyPool)
        {
            if (!enemy.enabled)
            {
                enemy.transform.position = spawnPosition;
                enemy.enabled = true;
                return enemy;
            }
        }
        GameObject newEnemy = Instantiate(enemyPrefab);
        newEnemy.transform.position = spawnPosition;
        newEnemy.SetActive(true);
        enemyPool.Add(newEnemy.GetComponent<Enemy>());

        return newEnemy.GetComponent<Enemy>();
    }
    public void DespawnEnemy(GameObject enemy)
    {
        enemy.SetActive(false);
    }
}

