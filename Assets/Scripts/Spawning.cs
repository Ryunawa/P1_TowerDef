using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Spawning : MonoBehaviour
{
    public int compteur = 0;
    public GameObject ennemy;
    public static Spawning spawnManager;

    private Transform spawnerPos;
    float time;
    GameObject copieEnnemy;




    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        spawnerPos = transform;
        time = Time.time;

        //StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        float currTime = Time.time;
        if (compteur < 10 && currTime - time > 1)
        {
            copieEnnemy = Instantiate(ennemy);
            copieEnnemy.transform.position = spawnerPos.position;
            copieEnnemy.GetComponent<RoadToGoal>().spawnerSous = this.gameObject;

            new WaitForSeconds(1);
            time = currTime;
            compteur++;
        
        }
    }

    IEnumerator Spawn()
    {
        float currTime;
        while (compteur < 10)
        {
            currTime = Time.time;

            if (currTime - time < 1)
            {
                copieEnnemy = Instantiate(ennemy);
                copieEnnemy.transform.position = spawnerPos.position;
                copieEnnemy.GetComponent<RoadToGoal>().spawnerSous = this.gameObject;

                new WaitForSeconds(1);
                time = currTime;
                compteur++;
            }
        }
            yield return WaitSpawn();
            
    }

    IEnumerator WaitSpawn()
    {
        new WaitForSeconds(20);
        yield return Spawn();
    }
}
