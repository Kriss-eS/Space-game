using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelWonUI;
    public void GameOver()
    {
        if (LifeManager.gameOver)
        {
            Invoke("RestartLevel", 3f);
        }
    }

    public void WonLevel()
    {
        //Debug.Log(Enemy.enemiesAlive);
        if (Enemy.enemiesAlive <= 0)
        {
            levelWonUI.SetActive(true);
        }
        
    }

    public void RestartLevel()
    {
        LifeManager.gameOver = false;
        LifeManager.lives = 3;
        Enemy.enemiesAlive = 0;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameOver();
        WonLevel();
    }
}
