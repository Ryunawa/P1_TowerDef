using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public GameObject healthBarUI;
    public Slider slider;
    public Camera mainCamera;

    private void Start()
    {
        health = maxHealth;
        slider.value = CalculateHealth();
    }

    private void Update()
    {
        slider.value = CalculateHealth();
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
            Destroy(gameObject);
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
}
