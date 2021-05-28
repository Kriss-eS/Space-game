using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyFire : MonoBehaviour
{
    public GameObject bullet;
    public bool fire;
    // Start is called before the first frame update
    void Start()
    {
        if (fire)
        {
            InvokeRepeating("Fire", Random.Range(1, 10.0f), Random.Range(0.2f, 35.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void Fire()
    {
        Instantiate(bullet, new Vector2(transform.position.x, transform.position.y - 0.5f), Quaternion.identity);
    }

    private void OnBecameVisible()
    {
        Destroy(gameObject);
    }
}
