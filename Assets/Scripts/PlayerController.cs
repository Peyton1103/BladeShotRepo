using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRb;
    public float speed;
    public float horizontalInput;
    public float verticalInput;
    public float jumpForce = 5;
    public GameObject projectile;
    public bool isOnGround = true;
    public float gravityModifier;
    private GameManager GameManager;
    private float leftBound = -11;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics2D.gravity *= gravityModifier;
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && isOnGround && GameManager.isGameActive == true)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
            isOnGround = false;
        }

        if (Input.GetKeyDown(KeyCode.Z) && GameManager.isGameActive == true)
        {
            Instantiate(projectile, transform.position, projectile.transform.rotation);
        }

        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
            GameManager.GameOver();
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            

        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            GameManager.GameOver();

        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("EvilShot"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            GameManager.GameOver();
        }
    }




}
