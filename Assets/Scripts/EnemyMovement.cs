using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float maxX = 7;
    public float minX = -7;
    public float speed = 2/1000f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var enemyX = transform.position.x + speed;

        transform.position = new Vector2(enemyX, transform.position.y);

        if (transform.position.x > maxX)
        {
            moveDown();

        }
        else if (transform.position.x < minX)
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
