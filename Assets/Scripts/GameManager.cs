using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool isGameActive;
    public bool gameOver;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    public GameObject dialouge;
    public bool dialougeBox;
    public int enemyRemain;
    public TextMeshProUGUI enemyText;
    
    


    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        isGameActive = false;
        dialougeBox = false;
        dialouge.gameObject.SetActive(false);
        Cursor.visible = false;
        enemyText.enabled = false;
        




    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameActive && !gameOver && !dialougeBox )
        {
            Dialouge();
        }

        if (Input.GetKeyDown(KeyCode.Z) && !isGameActive && !gameOver && dialougeBox)
        {
            StartGame();
        }
        
        if (enemyRemain == 0)
        {
            NextWave();
        }

        if (gameOver && !isGameActive && (Input.GetKeyDown(KeyCode.Space)))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }

    }

    public void enemyRemaining(int enemyDefeat)
    {
        enemyRemain -= enemyDefeat;
        enemyText.text = "Remaining: " + enemyRemain;
    }


    public void StartGame()
    {
        isGameActive = true;
        dialouge.gameObject.SetActive(false);
        enemyText.enabled = true;

    }
    
    public void Dialouge()
    {
        dialougeBox = true;
        dialouge.gameObject.SetActive(true);
        titleScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
        gameOver = true;
    }

    public void NextWave()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        if (sceneName == "Wave1_Start")
        {
            SceneManager.LoadScene("Wave2");
        }

        if (sceneName == "Wave2")
        {
            SceneManager.LoadScene("Wave3_Final");
        }

        if (sceneName == "Wave3_Final")
        {
            SceneManager.LoadScene("EndScreen");
        }
    }

    
}
