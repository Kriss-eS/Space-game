using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject levelWonUI;
    public static float screenMaxX;
    public static float screenMinX;
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
