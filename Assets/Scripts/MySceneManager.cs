using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    public void nextLvl()
    {
        Spawning.waveCount = 0;
        Base.hpBase = 10;
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        Spawning.waveCount = 0;
        Base.hpBase = 10;
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

    public void Quit()
    {
        print("QUIT");
        Application.Quit();
    }
}
