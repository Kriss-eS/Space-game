using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject DeathSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            // N�r enemy d�r skapas en DeathSprite p� positionen av enemy.
            var deathsprite = Instantiate(DeathSprite, gameObject.transform.position, Quaternion.identity);

            // F�r att DeathSprite ocks� ska p�verkas av EnemyRowens EnemyMovement, g�r vi den en parent av EnemyRow. 
            deathsprite.transform.parent = GameObject.Find("EnemyRow").transform;
            Destroy(deathsprite, 0.5f);
        }
    }
    // Update is called once per frame
    void Update()
    {
     
    }
}
