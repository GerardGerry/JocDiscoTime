using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    EnemySpawner spawn;
    [SerializeField]
    List<GameObject> spawnList;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        Debug.Log("Spawning enemies");
            spawnList.ActivateSpawn();
        
    }
    
}
