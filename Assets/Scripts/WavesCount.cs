using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WavesCount : MonoBehaviour
{
    private TextMeshProUGUI _countWaveUpdate;
    public GameObject waveCount;

    // Start is called before the first frame update
    void Start()
    {
        _countWaveUpdate = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _countWaveUpdate.text = Spawning.waveCount.ToString();
    }
}
