using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RoadToGoal : MonoBehaviour
{

    public Transform goal;
    NavMeshAgent agent;
    public GameObject spawnerSous;

    int hp = 10;
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
            spawnerSous.GetComponent<Spawning>().compteur--;
            print(spawnerSous.GetComponent<Spawning>().compteur);
            Destroy(this.gameObject);
            
        }
    }
    public void att(int i)
    {
        hp -= i;
        print(hp);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
