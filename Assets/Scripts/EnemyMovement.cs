using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2/1000f;

    // Update is called once per frame
    void Update()
    {
        var enemyX = transform.position.x + speed;

        transform.position = new Vector2(enemyX, transform.position.y);

        if (transform.position.x + transform.position.x / 2 >= GameManager.screenMaxX)
        {
            moveDown();

        }
        else if (transform.position.x + transform.position.x / 2 <= GameManager.screenMinX)
        {
            moveDown();
        }
    }

    void moveDown()
    {
        speed *= -1;
        transform.position = new Vector2(transform.position.x, transform.position.y - 1);
    }
}
