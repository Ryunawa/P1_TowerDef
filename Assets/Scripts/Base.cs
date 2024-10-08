using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameManager objective;
    public static int hpBase = 10;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject touch = other.gameObject;

        if (touch.CompareTag("Ennemi"))
        {
            hpBase--;
            Destroy(other.gameObject); // Destroy the enemy

            objective.MenuEndGame();
        }
    }
}
