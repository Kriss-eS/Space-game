using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private float maxX;
    private float minX;
    public float speed = 2/1000f;
    // Start is called before the first frame update
    void Start()    
    {
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        maxX = topCorner.x;
        minX = bottomCorner.x;
    }

    // Update is called once per frame
    void Update()
    {
        var enemyX = transform.position.x + speed;

        transform.position = new Vector2(enemyX, transform.position.y);

        if (transform.position.x + transform.position.x/2 >= maxX)
        {
            moveDown();

        }
        else if (transform.position.x + transform.position.x/2 <= minX)
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
