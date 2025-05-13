using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBounds : MonoBehaviour
{
    private float leftBound = -11;
    private GameManager GameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < leftBound)
        {
            Destroy(gameObject);
            GameManager.GameOver();
        }
    }
}
