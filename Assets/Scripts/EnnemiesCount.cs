using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EnnemiesCount : MonoBehaviour
{

    private TextMeshProUGUI countUpdate;
    public GameObject count;

    // Start is called before the first frame update
    void Start()
    {
        countUpdate = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        countUpdate.text = count.GetComponent<Spawning>().compteur.ToString();
        print("text au pif " + count.GetComponent<Spawning>().compteur.ToString());
    }
}


