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
            // När enemy dör skapas en DeathSprite på positionen av enemy.
            var deathsprite = Instantiate(DeathSprite, gameObject.transform.position, Quaternion.identity);

            // För att DeathSprite också ska påverkas av EnemyRowens EnemyMovement, gör vi den en parent av EnemyRow. 
            deathsprite.transform.parent = GameObject.Find("EnemyRow").transform;
            Destroy(deathsprite, 0.5f);
        }
    }

    // Istället för sänka värdet på enemiesAlive i OnTriggerEnter2D,
    // görs det på OnDestroy för att försäkra att värdet bara sänks när objektet verkligen har blivit destroyat.
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
