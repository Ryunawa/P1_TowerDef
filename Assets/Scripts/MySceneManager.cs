using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    string nextBuildLvl = "SceneManager.GetActiveScene().buildIndex + 1";
    public void loadNextLvl()
    {
        Spawning.waveCount = 0;
        Base.hpBase = 10;
        Time.timeScale = 1;

        SceneManager.LoadScene(nextBuildLvl);
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
