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
        // if the distance between the ennemy and the goal is under 0.2, the agent is destroyed
        if (agent.remainingDistance < 0.2)
        {
            Destroy(gameObject);
            print(spawnerSous.GetComponent<Spawning>().compteur);
        }
    }

    private void OnDestroy()
    {
        spawnerSous.GetComponent<Spawning>().compteur--;
    }
}
