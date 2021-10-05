using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoadToGoal : MonoBehaviour
{

    public Transform goal;
    NavMeshAgent agent;
    public GameObject spawnerSous;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;

    }

    // Update is called once per frame
    void Update()
    {
        if (agent.remainingDistance < 0.2)
        {
            spawnerSous.GetComponent<Spawning>().compteur--;
            print(spawnerSous.GetComponent<Spawning>().compteur);
            Destroy(this.gameObject);
            print("C'est bon, c'est arrive");
            
        }
    }
}
