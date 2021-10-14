using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Objective : MonoBehaviour
{
    public GameObject textGoWin;
    public GameObject textGoLoose;
    public GameObject win;

    public void MenuEndGame()
    {
        if (Base.hpBase == 0)
        {
            gameObject.SetActive(true);
            textGoWin.SetActive(false);
            textGoLoose.SetActive(true);
            Time.timeScale = 0;
        }

        if (Spawning.waveCount >= 3 && !Spawning.spawnEnCours && Spawning.enemyCount <= 0)
        {
            print("c'est gg wp");
            gameObject.SetActive(true);
            textGoLoose.SetActive(false);
            textGoWin.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void Restart()
    {
        Spawning.waveCount = 0;
        Time.timeScale = 1;
        SceneManager.LoadScene("Lv1");
    }

    public void Quit()
    {
        print("QUIT");
        Application.Quit();
    }

}