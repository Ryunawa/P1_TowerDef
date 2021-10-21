using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager GM;

    public GameObject MenuWin;
    public GameObject MenuLoose;
    public int money = 50;

    private void Awake()
    {
        if(GM != null)
        {
            Destroy(GM);
        }
        else
        {
            GM = this;
        }
        money = 50;
    }

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

// MainMenu buttons
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Lv1", LoadSceneMode.Single);
    }
    public void LoadLevel2()
    {
        SceneManager.LoadScene("Lv2", LoadSceneMode.Single);
    }

    public void QuitGame()
    {
        print("QUIT");
        Application.Quit();
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

    public void GainMoney(int addedMoney)
    {
        money += addedMoney;
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

    public void Menu()
    {
        Spawning.waveCount = 0;
        Base.hpBase = 10;
        Time.timeScale = 1;

        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }
}
