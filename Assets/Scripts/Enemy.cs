using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int enemiesAlive;
    public GameObject DeathSprite;
    public static float boundsX;

    void Start()
    {
        var spriteRenderer = GetComponent<Collider2D>();
        boundsX = spriteRenderer.bounds.size.x;

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
            enemiesAlive--;
            // När enemy dör skapas en DeathSprite på positionen av enemy.
            var deathsprite = Instantiate(DeathSprite, gameObject.transform.position, Quaternion.identity);

            // För att DeathSprite också ska påverkas av EnemyRowens EnemyMovement, gör vi den en parent av EnemyRow. 
            deathsprite.transform.parent = GameObject.Find("EnemyRow").transform;
            Destroy(deathsprite, 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
