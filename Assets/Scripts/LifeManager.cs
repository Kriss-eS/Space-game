using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeManager : MonoBehaviour
{
    public static int lives = 3;
    public GameObject heart1, heart2, heart3;
    public static bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (lives == 3)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(true);
        }
        else if (lives == 2)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(true);
            heart3.gameObject.SetActive(false);
        }
        else if (lives == 1)
        {
            heart1.gameObject.SetActive(true);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);
        }
        else
        {
            gameOver = true;
        }
    }
}
