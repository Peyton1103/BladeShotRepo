using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorFlying : MonoBehaviour
{
    public float speed = 10.0f;
    public float health = 3;
    private GameManager GameManager;
    public int enemyValue;


    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);

        if (health == 0)
        {
            Destroy(gameObject);
            GameManager.enemyRemaining(enemyValue);
        }

        if (GameManager.enemyRemain == 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        health -= 1;
        Destroy(other.gameObject);
    }
}
