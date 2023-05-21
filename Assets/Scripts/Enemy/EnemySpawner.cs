using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, ItSpawns
{
    [SerializeField] private float spawnRate = 1f;

    [SerializeField] private GameObject[] enemyPrefabs;

    [SerializeField] private bool canSpawn = true;

    [SerializeField] float maxSpawnTime = 10.0f;
    float timer = 0f;

    private void Start()
    {
       
    }

    public void ActivateSpawn()
    {
        StartCoroutine(Spawner());
        timer += Time.deltaTime;
        //if (collision == collision.GetComponent("spawnTest"))
        //{
        //    StartCoroutine(Spawner());
        //}
    }
    public void StopSpawn()
    {
        canSpawn = false;
    }
    private IEnumerator Spawner() { 
    
        WaitForSeconds wait = new WaitForSeconds(spawnRate);
       
        
        while (canSpawn)
        {
            
            yield return wait;
            int rand = Random.Range(0, enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);
            
            if (timer >= maxSpawnTime) { canSpawn = false; }

        }
    } 
}
