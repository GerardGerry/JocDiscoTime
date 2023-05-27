using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    EnemySpawner spawn1;
    EnemySpawner spawn2;
    EnemySpawner spawn3;
    EnemySpawner spawn4;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawn1 = GameObject.Find("Spawner_1").GetComponentInChildren<EnemySpawner>();
        spawn2 = GameObject.Find("Spawner_2").GetComponentInChildren<EnemySpawner>();
        spawn3 = GameObject.Find("Spawner_3").GetComponentInChildren<EnemySpawner>();
        spawn4 = GameObject.Find("Spawner_4").GetComponentInChildren<EnemySpawner>();
      
                Debug.Log("Spawning enemies");
                spawn1.ActivateSpawn();
                spawn2.ActivateSpawn();
                spawn3.ActivateSpawn();
                spawn4.ActivateSpawn();
    }
    
}
