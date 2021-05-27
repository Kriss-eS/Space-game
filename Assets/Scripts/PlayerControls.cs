using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    Rigidbody2D rb;
    float xInput;
    public float speed = 7;
    public GameObject bullet;
    public Transform shootPosition;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(xInput * speed, 0);


        if (Input.GetKeyDown("space"))
        {
            FirePlayerBullet();
        }
    }
    void FirePlayerBullet()
    {
        Instantiate(bullet, shootPosition.position, transform.rotation);
    }
}