using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public GameObject[] powerupPrefab;
    public int bossWave = 5;
    public GameObject bossPrefab;

    // Start is called before the first frame update
    void Start()
    {  
       int index = Random.Range(0, powerupPrefab.Length);
       SpawnEnemyWave(waveNumber);
       Instantiate(powerupPrefab[index], GenerateSpawnPosition(), powerupPrefab[index].transform.rotation);
    }
    
    // Spawn enemy waves
    void SpawnEnemyWave(int enemiesToSpawn)
    {
        //spawns random enemies
        int index = Random.Range(0, enemyPrefabs.Length);

        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefabs[index], GenerateSpawnPosition(), enemyPrefabs[index].transform.rotation);
        }
    }

    // Creates spawn locations for enemy Prefab
    private Vector3 GenerateSpawnPosition()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length;
        if (enemyCount == 0)
        {
            int index = Random.Range(0, powerupPrefab.Length);
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab[index], GenerateSpawnPosition(), powerupPrefab[index].transform.rotation);


        }
        
        if (waveNumber == bossWave)
        {
            bossWave = bossWave + 5;
            Instantiate(bossPrefab, GenerateSpawnPosition(), bossPrefab.transform.rotation);
        }
    }
}
