using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    EnemySpawner spawn;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        var createEnemies = collision.GetComponent<ItSpawns>();
        if (collision.GetComponent<EnemySpawner>())
        {
            createEnemies.ActivateSpawn();
        }
    }
    
}
