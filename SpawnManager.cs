using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] spawnList;
    public float spawnSize = 20;
    public float spawnPosZ = 20;
    private float startDelay = 2;
    private float spawnInterval = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnRandomPlate", startDelay, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
       
    } 
    
    void SpawnRandomPlate()
{
    
    { int spawnIndex = Random.Range(0, spawnList.Length);
      Vector3 spawnPos = new Vector3(Random.Range(-spawnSize, spawnSize), 0, spawnPosZ);
      Instantiate(spawnList[spawnIndex], spawnPos, spawnList[spawnIndex].transform.rotation);
    }
    }
}
