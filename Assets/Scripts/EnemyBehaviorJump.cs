using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviorJump : MonoBehaviour
{
    public float speed = 10.0f;
    public float health = 3;
    private GameManager GameManager;
    public int enemyValue;
    private Rigidbody2D jumperRb;
    public float jumpForce = 5;
    public float gravityModifier;



    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        jumperRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumperRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);


        }
    }
}
