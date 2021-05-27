using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject SpaceMan;

    // Start is called before the first frame update
    void Start()
    {
        // Istället för att placera alla enemies för hand gör vi en loop som fungerar
        // som en cloner med offset. 

        // Vi säger att offset mellan varje enemy ska vara 1.1 i x värdet. 
        var offset = new Vector2(1.1f, 0);

        // totalt 11 enemies
        Cloner(6, offset);
    }

    void Cloner(int amount, Vector3 offset)
    {

        for (int i = 1; i <= amount; i++)
        {
            // Eftersom det finns en SpaceMan i EnemyRow använder vi dens position som utgångspunkt.
            // Sedan lägger vi till offset.
            // Medans vi ändå håller på att skapa objektet specificerar vi vilken parent den ska ha,
            // i det här fallet EnemyRow.

            // Om antalet är jämnt
            if (amount % 2 == 0)
            {
                // I första hälften av antalet, spawna SpaceMans åt vänster
                if (i <= amount / 2)
                {
                    // offset * i eftersom förskjutningen måste ökas varje loop, annars spawnar dom på samma ställe
                    // vi kompenserar också offset för när vi senare tar bort SpaceMannen i mitten
                    Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position - (offset * i) + offset * 0.5f, Quaternion.identity)
                        .transform.parent = GameObject.Find("EnemyRow").transform;
                    enemiesSpawned();
                }
                // I andra hälften av antalet, spawna SpaceMans åt höger
                else if (i > amount / 2)
                {
                    Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position + (offset * (i - amount / 2)) - offset * 0.5f, Quaternion.identity)
                        .transform.parent = GameObject.Find("EnemyRow").transform;
                    enemiesSpawned();
                }

                // Om vi har nått slutet av loopen, ta bort SpaceMannen i mitten.
                if (i == amount)
                {
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                }
            }
            // Om antalet inte är jämnt
            else
            {
                if (i <= amount / 2)
                {
                    Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position - (offset * i), Quaternion.identity)
                        .transform.parent = GameObject.Find("EnemyRow").transform;
                    enemiesSpawned();
                }
                else if (i > amount / 2)
                {
                    // skippa den sista eftersom vi behåller den i mitten
                    if (i == amount)
                    {
                        break;
                    }
                    Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position + (offset * (i - amount / 2)), Quaternion.identity)
                        .transform.parent = GameObject.Find("EnemyRow").transform;
                    enemiesSpawned();
                }
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
