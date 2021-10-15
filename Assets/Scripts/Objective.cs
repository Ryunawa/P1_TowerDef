using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    public GameObject MenuWin;
    public GameObject MenuLoose;
    
    public void Start()
    {
        MenuWin.SetActive(false);
        MenuLoose.SetActive(false);
        
    }
    public void MenuEndGame()
    {
        if (Base.hpBase == 0)
        {
            MenuLoose.SetActive(true);
            Time.timeScale = 0;
        }

        if (Spawning.waveCount >= 6 && !Spawning.spawnEnCours && Spawning.enemyCount <= 0)
        {
            MenuWin.SetActive(true);
            Time.timeScale = 0;
        }
    }
}