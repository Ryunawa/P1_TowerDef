using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyCount : MonoBehaviour
{
    private TextMeshProUGUI _countMoneyUpdate;
    public GameObject moneyCount;

    // Start is called before the first frame update
    void Start()
    {
        _countMoneyUpdate = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        _countMoneyUpdate.text = moneyCount.GetComponent<GameManager>().money.ToString(); // Update the text, here the current amount of money
    }
}
