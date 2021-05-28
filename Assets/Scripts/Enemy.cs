using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int enemiesAlive = 0;
    public static Vector2 boxColSize;
    public GameObject DeathSprite;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            // N�r enemy d�r skapas en DeathSprite p� positionen av enemy.
            var deathsprite = Instantiate(DeathSprite, gameObject.transform.position, Quaternion.identity);

            // F�r att DeathSprite ocks� ska p�verkas av EnemyRowens EnemyMovement, g�r vi den en parent av EnemyRow. 
            deathsprite.transform.parent = GameObject.Find("EnemyRow").transform;
            Destroy(deathsprite, 0.5f);
        }
    }

    // Ist�llet f�r s�nka v�rdet p� enemiesAlive i OnTriggerEnter2D,
    // g�rs det p� OnDestroy f�r att f�rs�kra att v�rdet bara s�nks n�r objektet verkligen har blivit destroyat.
    void OnDestroy()
    {
        enemiesAlive--;
    }
    // Update is called once per frame
    void Update()
    {
    }

    void Start()
    {
    }
}
