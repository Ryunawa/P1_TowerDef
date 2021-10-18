using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnemiesCount : MonoBehaviour
{
    private TextMeshProUGUI _countEnemyUpdate;
    public GameObject enemyCount;
    

    // Start is called before the first frame update
    void Start()
    {
        _countEnemyUpdate = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _countEnemyUpdate.text = Mathf.Round(Spawning.enemyCount).ToString(); //Update the text, here the current enemy count
    }
}


