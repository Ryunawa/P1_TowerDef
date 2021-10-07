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
        agent.destination = goal.position;  // Set the destination to the ennemy 

    }

    // Update is called once per frame
    void Update()
    {
        // If the distance between the ennemy and the goal is under 0.2, the agent is destroyed
        if (agent.remainingDistance < 0.2)
        {
            Destroy(gameObject);  // Destroy the ennemy
            print(spawnerSous.GetComponent<Spawning>().compteur);
        }
    }

    private void OnDestroy()
    {
        spawnerSous.GetComponent<Spawning>().compteur--;
    }
}
