using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    public GameObject textGoWin;
    public GameObject textGoLoose;
    public void Start()
    {
        gameObject.SetActive(false);
    }
    public void MenuEndGame()
    {
        if (Base.hpBase == 0)
        {
            gameObject.SetActive(true);
            textGoWin.SetActive(false);
            textGoLoose.SetActive(true);
            Time.timeScale = 0;
        }

        if (Spawning.waveCount >= 6 && !Spawning.spawnEnCours && Spawning.enemyCount <= 0)
        {
            gameObject.SetActive(true);
            textGoLoose.SetActive(false);
            textGoWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        Spawning.waveCount = 0;
        Base.hpBase = 10;
        Time.timeScale = 1;
        SceneManager.LoadScene("Lv1");
    }

    public void Quit()
    {
        print("QUIT");
        Application.Quit();
    }

}