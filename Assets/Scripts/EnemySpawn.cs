using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public GameObject[] enemyPrefabs;
    private float spawnPosX = 12;
    private GameManager GameManager;
    public float timeToSpawn;
    public float spawnCountdown;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawnCountdown = timeToSpawn;
       
    }

    // Update is called once per frame
    void Update()
    {
        spawnCountdown -= Time.deltaTime;
        if (GameManager.isGameActive == true && (spawnCountdown <= 0) && GameManager.enemyRemain >= 0)
        {
            spawnCountdown = timeToSpawn;

            SpawnRandomEnemy();
        }
    }

    void SpawnRandomEnemy()
    {
        Vector3 spawnPos = new Vector3(spawnPosX, 3, -0.45f);
        int enemyIndex = Random.Range(0, enemyPrefabs.Length);

        Instantiate(enemyPrefabs[enemyIndex], spawnPos,
        enemyPrefabs[enemyIndex].transform.rotation);
    }
    
}
