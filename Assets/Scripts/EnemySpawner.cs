using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject SpaceMan;
    float offsetX = 1.1f;
    float offsetY = 1f;
    public int amount;
    public int rows;

    // Ist�llet f�r att placera alla enemies f�r hand g�r vi en spawner som hanterar det.

    // Start is called before the first frame update
    private void Awake()
    {
        SpawnRows(amount, rows, offsetX, offsetY);
        EnemyMovement.waitTime = Time.time;
    }

 
    void Start()
    {
    }

    //void Spawner(int amount, int rows, Vector3 offset)
    //{
    //    for (int i = 1; i <= amount; i++)
    //    {
    //        // Eftersom det finns en SpaceMan i EnemyRow anv�nder vi dens position som utg�ngspunkt.
    //        // Sedan l�gger vi till offset.
    //        // Medans vi �nd� h�ller p� att skapa objektet specificerar vi vilken parent den ska ha,
    //        // i det h�r fallet EnemyRow.

    //        // Om antalet �r j�mnt
    //        if (amount % 2 == 0)
    //        {
    //            // I f�rsta h�lften av antalet, spawna SpaceMen �t v�nster
    //            if (i <= amount / 2)
    //            {
    //                // offset * i eftersom f�rskjutningen m�ste �kas varje loop, annars spawnar dom p� samma st�lle
    //                // vi kompenserar ocks� offset f�r n�r vi senare tar bort SpaceMannen i mitten
    //                Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position - (offset * i) + offset * 0.5f, Quaternion.identity)
    //                    .transform.parent = gameObject.transform;
    //                enemiesSpawned();
    //            }
    //            // I andra h�lften av antalet, spawna SpaceMen �t h�ger
    //            else if (i > amount / 2)
    //            {
    //                Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position + (offset * (i - amount / 2)) - offset * 0.5f, Quaternion.identity)
    //                    .transform.parent = gameObject.transform;
    //                enemiesSpawned();
    //            }

    //            // Om vi har n�tt slutet av loopen, ta bort SpaceMannen i mitten.
    //            if (i == amount)
    //            {
    //                Destroy(gameObject.transform.GetChild(0).gameObject);
    //            }
    //        }
    //        // Om antalet inte �r j�mnt
    //        else
    //        {
    //            if (i <= amount / 2)
    //            {
    //                Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position - (offset * i), Quaternion.identity)
    //                    .transform.parent = gameObject.transform;
    //                enemiesSpawned();
    //            }
    //            else if (i > amount / 2)
    //            {
    //                // skippa den sista eftersom vi beh�ller den i mitten
    //                if (i == amount)
    //                {
    //                    break;
    //                }
    //                Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position + (offset * (i - amount / 2)), Quaternion.identity)
    //                    .transform.parent = gameObject.transform;
    //                enemiesSpawned();
    //            }
    //        }
    //    }

    //}


    // Skrev om spawn metoden, mycket snyggare nu :D
    void SpawnRows(int amount, int rows, float offsetX, float offsetY)
    {
        BoxCollider2D collider = SpaceMan.GetComponent<BoxCollider2D>();
        float spacemanWidth = collider.size.x / 10;
        spacemanWidth *= amount - spacemanWidth / 2 + offsetX * amount-1;
         
        for (int j = 0; j < rows; j++)
        {
            for (int i = 0; i < amount; i++)
            {
                Instantiate(SpaceMan, new Vector2(-spacemanWidth/2 + i * offsetX, transform.position.y - offsetY * j), Quaternion.identity)
                    .transform.parent = transform;
                enemiesSpawned();
            }
        }
    }

    public void enemiesSpawned()
    {
        Enemy.enemiesAlive++;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
