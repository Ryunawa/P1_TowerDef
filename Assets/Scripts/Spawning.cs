using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class Spawning : MonoBehaviour
{
    public static float enemyCount = 0;
    public static int waveCount = 0;
    public GameObject ennemy;
    public static Spawning spawnManager;
    public static bool spawnEnCours;
    public float enemyMax = 0;
    public float spawnTmp = 0.5f;
    public Objective objective;

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
            enemyMax += 5;
            spawnEnCours = true;  
            enemyCount = enemyMax;
           
            yield return new WaitForSeconds(2);

            for (i = 0; i < enemyMax ; i++)
            {
                copieEnnemy = Instantiate(ennemy);  // Create a new ennemy
                copieEnnemy.transform.position = _spawnerPos.position;  // Set the ennemy spawn
                copieEnnemy.GetComponent<RoadToGoal>().spawnerSous = this.gameObject;  //Allow to soustrate to the count

                yield return new WaitForSeconds(spawnTmp);  // Let 0.5 seconds between two spawn
            }

            spawnEnCours = false;

            while(enemyCount > 0)
            {
                yield return new WaitForSeconds(0.1f);
            }
            objective.MenuEndGame();

            
            spawnTmp *= 0.9f;

            yield return new WaitForSeconds(3);
        }
    }

    private void OnDestroy()
    {
        StopAllCoroutines();
    }

}
