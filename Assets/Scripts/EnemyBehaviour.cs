using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyBehaviour : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;

    UnityEngine.AI.NavMeshAgent agent;

    public Transform goal;
    public GameObject spawnerSous;

    float reduceRate = 1;
    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = goal.position;  // Set the destination to the ennemy 


    }

    private void Update()
    {
        slider.value = CalculateHealth();
        transform.localScale = transform.localScale * reduceRate;

    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void DealtDamage(int dmg)
    {
        health -= dmg;

        if (health <= 0)
        {
            Animator a = GetComponentInChildren<Animator>();
            a.SetBool("Vivant", false);
            Destroy(agent);
            gameObject.tag = "Untagged";
            Destroy(gameObject, 2);
           // StartCoroutine("mort");
        }

        if (health > maxHealth)
        {
            health = maxHealth;
        }

        if (health < maxHealth)
        {
            healthBarUI.SetActive(true);
        }
    }
        private void OnDestroy()
    {
        if (spawnerSous != null)
        {
            spawnerSous.GetComponent<Spawning>().enemyCount--;
        }
    }

    IEnumerator mort()
    {
        yield return new WaitForSeconds(1);
        reduceRate = 0.99f;
    }
}