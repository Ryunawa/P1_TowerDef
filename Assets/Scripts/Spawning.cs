using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Spawning : MonoBehaviour
{
    public int enemyCount = 0;
    public static int waveCount = 0;
    public GameObject ennemy;
    public static Spawning spawnManager;
    public bool spawnEnCours;
    public float enemyMax = 10;

    private Transform _spawnerPos;
    GameObject copieEnnemy;




    // Start is called before the first frame update
    void Start()
    {
        NavMeshAgent agent = GetComponent<NavMeshAgent>();
        _spawnerPos = transform;
        StartCoroutine("Spawn");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        int i;
        while (true)
        {
            waveCount++;
            spawnEnCours = true;
            for (i = 0; i < enemyMax ; i++)
            {
                    copieEnnemy = Instantiate(ennemy);  // Create a new ennemy
                    copieEnnemy.transform.position = _spawnerPos.position;  // Set the ennemy spawn
                    copieEnnemy.GetComponent<RoadToGoal>().spawnerSous = this.gameObject;  //Allow to soustrate to the count
                    enemyCount++;

                yield return new WaitForSeconds(0.5f);  // Let 0.5 seconds between two spawn
            }
            spawnEnCours = false;

            enemyMax *= 1.2f; 


            yield return new WaitForSeconds(10);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
