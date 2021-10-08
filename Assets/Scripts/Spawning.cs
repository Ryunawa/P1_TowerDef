using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Spawning : MonoBehaviour
{
    public int compteur = 0;
    public int countSpawn;
    public GameObject ennemy;

    private Transform spawnerPos;
    GameObject copieEnnemy;




    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        spawnerPos = transform;

        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            while (compteur < 10)
            {
                    copieEnnemy = Instantiate(ennemy);  // Create a new ennemy
                    copieEnnemy.transform.position = spawnerPos.position;  // Set the ennemy spawn
                    copieEnnemy.GetComponent<RoadToGoal>().spawnerSous = this.gameObject;  //Allow to soustrate to the count

                    yield return new WaitForSeconds(0.5f);  // Let 0.5 seconds between two spawn

                    compteur++;
            }
            yield return new WaitForSeconds(15);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }


    IEnumerator WaitSpawn()
    {
        new WaitForSeconds(20);
        yield return Spawn();
    }
}
