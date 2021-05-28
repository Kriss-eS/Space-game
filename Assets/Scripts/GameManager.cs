using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelWonUI;
    public GameObject gameOver;
    public static float screenMaxX;
    public static float screenMinX;
    public string nextLevel;
    public void GameOver()
    {
        if (LifeManager.gameOver)
        {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in enemies)
            {
                Destroy(enemy);
            }
            gameOver.SetActive(true);
            Invoke("RestartLevel", 4f);
            
        }
    }
    public void WonLevel()
    {
        //Debug.Log(Enemy.enemiesAlive);
        if (Enemy.enemiesAlive <= 0 && !LifeManager.gameOver)
        {
            levelWonUI.SetActive(true);
            Enemy.enemiesAlive = 0;
            if (Input.GetKeyDown("space"))
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }

    public void RestartLevel()
    {
        LifeManager.gameOver = false;
        LifeManager.lives = 3;
        SceneManager.LoadScene("Level1");
    }
    void setMinMaxX()
    {
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        screenMaxX = topCorner.x;
        screenMinX = bottomCorner.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        setMinMaxX();
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        WonLevel();
    }
}
