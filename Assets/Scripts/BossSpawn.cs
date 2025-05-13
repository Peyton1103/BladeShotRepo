using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour
{
    private GameManager GameManager;
    public bool isBossSpawned = false;
    public GameObject evilBlade;
    

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        evilBlade.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.isGameActive == true && isBossSpawned == false)
        {
            
            isBossSpawned = true;
            evilBlade.gameObject.SetActive(true);
        }


    }
}
