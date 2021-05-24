using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{

    Rigidbody2D rb; //v.1
    float xInput; //v.1
    public float speed; //v.1

    public GameObject bullet; //v.2
    public Transform shootPosition; //v.2

    private void Awake() //v.1
    {
        rb = GetComponent<Rigidbody2D>(); //v.1
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal"); //v.1

        rb.velocity = new Vector2(xInput * speed, rb.velocity.y); //v.1

        if (Input.GetKeyDown("space")) //v.2
        {
            Fire(); //v.2
        }

        void Fire() //v.2
        {
            Instantiate(bullet, shootPosition.position, transform.rotation); //v.2
        }
    }
}
