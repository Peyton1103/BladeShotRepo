using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehavior : MonoBehaviour
{

    public float health = 30;
    private GameManager GameManager;
    public int enemyValue;
    private Rigidbody2D jumperRb;
    public float jumpForce = 5;
    public float gravityModifier;
    public GameObject evilProjectile;
    public float spawnRate = 2f;
    public float timeToSpawn;
    public float spawnCountdown;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        jumperRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;
        spawnCountdown = timeToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        if (health == 0)
        {
            Destroy(gameObject);
            GameManager.enemyRemaining(enemyValue);
        }

        if (GameManager.enemyRemain == 0)
        {
            Destroy(gameObject);
        }

        spawnCountdown -= Time.deltaTime;
        if (GameManager.isGameActive == true && (spawnCountdown <= 0) && GameManager.enemyRemain >= 0)
        {
            spawnCountdown = timeToSpawn;

            SpawnProjectile();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumperRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);


        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Shot"))
        {
            Destroy(other.gameObject);
            health -= 1;

        }


    }
    
    private void SpawnProjectile()
    {
        Instantiate(evilProjectile, transform.position, evilProjectile.transform.rotation);
    }
}
