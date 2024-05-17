using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float speed;
    private Rigidbody bossRb;
    private GameObject player;
    public GameObject[] enemyPrefabs;
    private float spawnRange = 9;

    // Start is called before the first frame update
    void Start()
    {
        bossRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
        InvokeRepeating("SpawnEnemies", 1, 1);
    }
    void SpawnEnemies(int enemiesToSpawn)
    {
        int index = Random.Range(0, enemyPrefabs.Length);
        for (int i = 0; i < enemiesToSpawn; i++)
        {
        Instantiate(enemyPrefabs[index], GenerateSpawnPosition(), enemyPrefabs[index].transform.rotation);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        bossRb.AddForce(lookDirection * speed);
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    private Vector3 GenerateSpawnPosition ()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }
}
