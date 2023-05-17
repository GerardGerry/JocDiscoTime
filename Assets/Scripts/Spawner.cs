using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    [SerializeField]
    GameObject Prefab;

    [SerializeField]
    [Range(0,1)]
    float SpawnProbabilty;


    // Start is called before the first frame update
    void Start()
    {
        MakeWall();
    }

    void MakeWall()
    {
        Vector3 pos = transform.position;
        for (int j = 0; j < 10; j++)
        {
            pos.y = transform.position.y + j;

            for (int i = 0; i < 10; i++)
            {
                pos.x = transform.position.x + i;
                MakeOne(pos);
            }
        }
       
    }

    void TryMakeOne(Vector3 pos)
    {
        if (Random.value < SpawnProbabilty)
            MakeOne(pos);
    }
    private void MakeOne(Vector3 pos)
    {
        Instantiate(Prefab, pos, transform.rotation);

        GameObject go = Instantiate(Prefab, pos, transform.rotation);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
