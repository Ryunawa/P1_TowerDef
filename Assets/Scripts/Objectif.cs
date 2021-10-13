using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objectif : MonoBehaviour
{
    public GameObject textGoWin;
    public GameObject textGoLoose;

    public GameObject win;
    private int _hpBase = 10;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        if (_hpBase == 0)
        {
            textGoWin.SetActive(false);
            textGoLoose.SetActive(true);
            Time.timeScale = 0;
        }

        if (Spawning.waveCount == 10 && !win.GetComponent<Spawning>().spawnEnCours && win.GetComponent<Spawning>().enemyCount == 0)
        {
            textGoLoose.SetActive(false);
            textGoWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        GameObject touch = other.gameObject;

        if (touch.CompareTag("Ennemi"))
        {
            _hpBase--;
            print("hp de la base :" + _hpBase);
            Destroy(other.gameObject); // Destroy the enemy
        }
    }

}

