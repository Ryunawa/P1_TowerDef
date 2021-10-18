using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject MenuWin;
    public GameObject MenuLoose;

// Start is called before the first frame update
    void Start()
    {
        MenuWin.SetActive(false);
        MenuLoose.SetActive(false);
    }

// Update is called once per frame
    void Update()
    {
        
    }

// Winning and loosing conditions
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

// Allow us to load the next lvl when you win and click on the right button
    public void LoadNextLvl()
    {
        Spawning.waveCount = 0;
        Base.hpBase = 10;
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

// Allow us to load the same lvl when you loose and click on the right button
    public void Restart()
    {
        Spawning.waveCount = 0;
        Base.hpBase = 10;
        Time.timeScale = 1;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
    }

// Allow us to load to quit when you click on the right button
    public void Quit()
    {
        print("QUIT");
        Application.Quit();
    }
}
