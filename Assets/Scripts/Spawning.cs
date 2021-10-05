using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Spawning : MonoBehaviour
{
    public int compteur = 0;
    public GameObject ennemy;
    private Transform spawnerPos;
    float time;

    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        spawnerPos = transform;
        time = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        float currTime = Time.time;
        GameObject copieEnnemy;
            if (compteur < 10 && currTime - time > 1)
            {
                copieEnnemy = Instantiate(ennemy);
                copieEnnemy.transform.position = spawnerPos.position;
                copieEnnemy.GetComponent<RoadToGoal>().spawnerSous = this.gameObject;


                time = currTime;
                compteur++;
            }
    }
}
