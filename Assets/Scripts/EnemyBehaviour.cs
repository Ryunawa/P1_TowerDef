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
    public Camera mainCamera;

    UnityEngine.AI.NavMeshAgent agent;

    public GameObject spawnerSous;

    float reduceRate = 1;
    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.destination = GameObject.FindWithTag("Goal").transform.position; // Set the destination to the ennemy 
   }

    private void Update()
    {
        slider.value = CalculateHealth();
        transform.localScale = transform.localScale * reduceRate;
        healthBarUI.transform.rotation = new Quaternion(0, mainCamera.transform.rotation.y, mainCamera.transform.rotation.z, 0);
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
            Destroy(agent);
            reduceRate = 0.98f;
            Destroy(gameObject, 0.25f);
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
            Spawning.enemyCount--;
        }
    }


}