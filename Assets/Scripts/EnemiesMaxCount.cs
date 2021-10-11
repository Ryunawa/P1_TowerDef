using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemiesMaxCount : MonoBehaviour
{
    private TextMeshProUGUI _countEnemyMaxUpdate;
    public GameObject enemyCountMax;

    // Start is called before the first frame update
    void Start()
    {
        _countEnemyMaxUpdate = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _countEnemyMaxUpdate.text = Mathf.Round(enemyCountMax.GetComponent<Spawning>().enemyMax).ToString();
    }
}
