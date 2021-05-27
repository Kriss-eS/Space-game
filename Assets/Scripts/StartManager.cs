using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartManager : MonoBehaviour
{
    public GameObject SpaceMan;

    // Start is called before the first frame update
    void Start()
    {
        // Ist�llet f�r att placera alla enemies f�r hand g�r vi en loop som fungerar
        // som en cloner med offset. 

        // Vi s�ger att offset mellan varje enemy ska vara 1.1 i x v�rdet. 
        var offset = new Vector2(1.1f, 0);

        // totalt 11 enemies
        Cloner(6, offset);
    }

    void Cloner(int amount, Vector3 offset)
    {

        for (int i = 1; i <= amount; i++)
        {
            // Eftersom det finns en SpaceMan i EnemyRow anv�nder vi dens position som utg�ngspunkt.
            // Sedan l�gger vi till offset.
            // Medans vi �nd� h�ller p� att skapa objektet specificerar vi vilken parent den ska ha,
            // i det h�r fallet EnemyRow.

            // Om antalet �r j�mnt
            if (amount % 2 == 0)
            {
                // I f�rsta h�lften av antalet, spawna SpaceMans �t v�nster
                if (i <= amount / 2)
                {
                    // offset * i eftersom f�rskjutningen m�ste �kas varje loop, annars spawnar dom p� samma st�lle
                    // vi kompenserar ocks� offset f�r n�r vi senare tar bort SpaceMannen i mitten
                    Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position - (offset * i) + offset * 0.5f, Quaternion.identity)
                        .transform.parent = GameObject.Find("EnemyRow").transform;
                    enemiesSpawned();
                }
                // I andra h�lften av antalet, spawna SpaceMans �t h�ger
                else if (i > amount / 2)
                {
                    Instantiate(SpaceMan, gameObject.transform.GetChild(0).transform.position + (offset * (i - amount / 2)) - offset * 0.5f, Quaternion.identity)
                        .transform.parent = GameObject.Find("EnemyRow").transform;
                    enemiesSpawned();
                }

                // Om vi har n�tt slutet av loopen, ta bort SpaceMannen i mitten.
                if (i == amount)
                {
                    Destroy(gameObject.transform.GetChild(0).gameObject);
                }
            }
            // Om antalet inte �r j�mnt
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
                    // skippa den sista eftersom vi beh�ller den i mitten
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
