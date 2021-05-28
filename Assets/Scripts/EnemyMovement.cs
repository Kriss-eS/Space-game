using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2 * 0.01f;
    private bool hasEntered;
    public static float waitTime;

    void Start()
    {
        transform.Translate(1 * Mathf.Abs(speed), 0, 0);
    }

    void FixedUpdate()
    {
        if (Time.time - waitTime > 1f)
        {
            transform.Translate(1 * speed, 0, 0);
        }
        if (transform.position.y == -4)
        {
            LifeManager.gameOver = true;
        }
       // enemyRow.MovePosition(new Vector2(transform.position.x + speed, transform.position.y));
        //if (movedown)
        //{
        //    transform.Translate(Vector2.down * speed);
        //    gameObject.GetComponent<Rigidbody2D>().position = new Vector2(transform.position.x, transform.position.y - 1);
        //    movedown=false;
        //}
    }

    // Detta fungerar eftersom s� l�nge man har en rigidbody p� parent, kommer f�r�ldern att f� 
    // collision events f�r alla collisions p� barn.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Walls") && !hasEntered)
        {
            float positionX = transform.position.x;
            int positionY = (int)transform.position.y; // kastar till int d� Y alltid kommer vara heltal vilket sparar performance. 
            hasEntered = true;
            transform.position = new Vector2(positionX, (positionY -1));
            speed *= -1;
        }
    }

    // Denna beh�vs s� att inte alla rader av enemies triggrar collision, det r�cker om en rad g�r det. 

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasEntered = false;
    }
}
