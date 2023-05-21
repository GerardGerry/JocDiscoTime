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
    float timer = 0.0f;
    bool stop = false;
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
        timer = 0;
        while(!stop)
        {
            Debug.Log(timer);
            timer = Time.deltaTime + timer;
            if(timer >= 10f)
            {
                stop = true;
                spawn1.StopSpawn();
                spawn2.StopSpawn();
                spawn3.StopSpawn();
                spawn4.StopSpawn();
                
            }
        }
    }
    
}
