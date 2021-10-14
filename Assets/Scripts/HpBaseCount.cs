using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HpBaseCount : MonoBehaviour
{
    private TextMeshProUGUI _countHpBaseUpdate;
    public GameObject hpBaseCount;
    // Start is called before the first frame update
    void Start()
    {
        _countHpBaseUpdate = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _countHpBaseUpdate.text = Base.hpBase.ToString();
    }
}
