using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class RoadToGoal : MonoBehaviour
{
    NavMeshAgent agent;

    public Transform goal;
    public GameObject spawnerSous;


    private int _hpEnemy = 10;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.destination = goal.position;  // Set the destination to the ennemy 

    }

    // Update is called once per frame
    void Update()
    {
  
    }
    public void att(int i)
    {
        _hpEnemy -= i;
        if (_hpEnemy <= 0)
        {
            
        }
    }

    private void OnDestroy()
    {
        if (spawnerSous != null)
        {
            spawnerSous.GetComponent<Spawning>().enemyCount--;
        }
    }
}
