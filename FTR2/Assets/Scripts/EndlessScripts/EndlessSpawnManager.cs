using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndlessSpawnManager : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private GameObject daisyPrefab;
    [SerializeField] private GameObject beePrefab;
  
    [Header("GameObjects")]
    [SerializeField] private GameObject butterfly;
    
    [Header("DaisySpawn")]
    [SerializeField] static public List<GameObject> spawnedDaisyList = new List<GameObject>();
    [SerializeField] private int maxDaisySpawnCount;
    static public int spawnedDaisyCount;

    [Header("BeeSpawn")]
    [SerializeField] private int maxBeeSpawnCount;
    [SerializeField] static public List<GameObject> spawnedBeeList = new List<GameObject>();
    static public int spawnedBeeCount;

    private void Start() 
    {
        spawnedDaisyCount = 0;
        spawnedBeeCount = 0;
    }

    private void Update() 
    {
        SpawnedDaisyControl();
        SpawnedBeeControl();
        DistanceBetweenBeeAndButterfly();
        DistanceBetweenDaisyAndButterfly();
    }

    private void DistanceBetweenBeeAndButterfly()
    {
        var posZ = butterfly.transform.position.z;
        for (int i = 0; i < spawnedBeeList.Count; i++)
        {
            if (spawnedBeeList[i].transform.position.z + 10 < posZ)
            {
                Destroy(spawnedBeeList[i]);
                spawnedBeeList.RemoveAt(i);
                spawnedBeeCount--;
                break;
            }
        }
    }
    private void DistanceBetweenDaisyAndButterfly()
    {
        var posZ = butterfly.transform.position.z;
        for (int i = 0; i < spawnedDaisyList.Count; i++)
        {
            if (spawnedDaisyList[i].transform.position.z + 10 < posZ)
            {
                Destroy(spawnedDaisyList[i]);
                spawnedDaisyList.RemoveAt(i);
                spawnedDaisyCount--;
                break;
            }
        }
    }

    private bool SpawnedDaisyControl()
    {
        if (spawnedDaisyCount < maxDaisySpawnCount)
        {
            SpawnDaisy();
            return true;
        }
        return false;
    }
    private bool SpawnedBeeControl()
    {
        if (spawnedBeeCount < maxBeeSpawnCount)
        {
            SpawnBee();
            return true;
        }
        return false;
    }

    private void SpawnDaisy()
    {
        while (spawnedDaisyCount < maxDaisySpawnCount)
        {
           if (spawnedDaisyList.Count < 1)
            {
                var spawnPos = butterfly.transform.position;
                var posY = Random.Range(1,9);
                var posZ = spawnPos.z + Random.Range(15,40);
                spawnPos.z = posZ;
                spawnPos.y = posY;
                    
                GameObject daisy = Instantiate(daisyPrefab,spawnPos,Quaternion.identity);
                daisy.tag = "Daisy";
                spawnedDaisyList.Add(daisy);
                spawnedDaisyCount++;  
            }
            else
            {
                var spawnPos = spawnedDaisyList[spawnedDaisyList.Count-1].transform.position;
                var posY = Random.Range(1,9);
                var posZ = spawnPos.z + Random.Range(15,40);
                spawnPos.z = posZ;
                spawnPos.y = posY;
                GameObject daisy = Instantiate(daisyPrefab,spawnPos,Quaternion.identity);
                daisy.tag = "Daisy";
                spawnedDaisyList.Add(daisy);
                spawnedDaisyCount++;
            }    
        }
    }
    private void SpawnBee()
    {
        while (spawnedBeeCount < maxBeeSpawnCount)
        {
            if (spawnedBeeList.Count < 1)
            {
                var spawnPos = butterfly.transform.position;
                var posY = Random.Range(1,9);
                var posZ = spawnPos.z + Random.Range(20,45);
                spawnPos.z = posZ;
                spawnPos.y = posY;
                
                GameObject bee = Instantiate(beePrefab,spawnPos,Quaternion.identity);
                bee.tag = "Bee";
                spawnedBeeList.Add(bee);
                spawnedBeeCount++;  
            }
            else
            {
                var spawnPos = spawnedBeeList[spawnedBeeList.Count-1].transform.position;
                var posY = Random.Range(1,9);
                var posZ = spawnPos.z + Random.Range(20,45);
                spawnPos.z = posZ;
                spawnPos.y = posY;
                GameObject bee = Instantiate(beePrefab,spawnPos,Quaternion.identity);
                bee.tag = "Bee";
                spawnedBeeList.Add(bee);
                spawnedBeeCount++;
            }
        }
    }
}