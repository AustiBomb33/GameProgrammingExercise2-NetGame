using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NetController : MonoBehaviour
{
    private float moveSpeed = 8f;
    private float lastSpawned;
    private int score = 0;
    private float spawnTime = 4f;
    public GameObject fishPrefab, bombPrefab, gameOverPanel;
    public Camera camera;
    public TextMeshProUGUI scoreText, gameOverScoreText;

    //Called when the object is initialized
    private void Start()
    {
        lastSpawned = Time.time;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Move the net left/Right
        float moveDir = Input.GetAxis("Horizontal");
        if ((moveDir < 0 && transform.position.x > camera.ViewportToWorldPoint(new Vector2(0, 0)).x + transform.localScale.x )|| //Ensure net cant move past left edge of viewport
            (moveDir > 0 && transform.position.x < camera.ViewportToWorldPoint(new Vector2(1, 0)).x - transform.localScale.x ))  //Ensure net cant move past right edge of viewport
        {
            transform.position = new Vector3(transform.position.x + moveDir * moveSpeed * Time.deltaTime, transform.position.y);
        }

        //check if object can be spawned yet
        if(Time.time - lastSpawned > spawnTime)
        {
            lastSpawned = Time.time;

            //choose random point within current viewport
            Vector2 spawnPoint = camera.ViewportToWorldPoint(new Vector2(Random.Range(0f, 1f), 1.2f));

            //80% chance to spawn fish, 20% bomb
            if(Random.Range(0f, 100f) < 80f)
            {
                Instantiate(fishPrefab, spawnPoint, Quaternion.identity, transform.parent);
            } else
            {
                Instantiate(bombPrefab, spawnPoint, Quaternion.identity, transform.parent);
            }
        }
    }

    //Increments score and updates UI text
    void Score()
    {
        score++;
        scoreText.text = "Score: " + score;
    }

    //Display "Game Over" Screen and pause time.
    void GameOver()
    {
        gameOverPanel.SetActive(true);
        gameOverScoreText.text = "Score: " + score;
        Time.timeScale = 0;
    }

    //reload the scene and unpause time
    void RestartGame()
    {
        SceneManager.LoadScene("Game Scene");
        Time.timeScale = 1;
    }
}
