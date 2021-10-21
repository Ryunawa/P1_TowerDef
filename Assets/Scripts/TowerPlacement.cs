using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public List<GameObject> basicTowers;
    GameObject copieTower;
    TurretAI turretScript;
    public GameObject moneyError;
    public GameObject xpError;
    public GameObject achat;
    public GameObject upgrade;

    public GameObject balistaButton;
    public GameObject cannonButton;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        achat.SetActive(false);
        upgrade.SetActive(false);
        moneyError.SetActive(false);
        balistaButton.GetComponentInChildren<TextMeshProUGUI>().text = basicTowers[0].GetComponentInChildren<TurretAI>().prix.ToString();
        cannonButton.GetComponentInChildren<TextMeshProUGUI>().text = basicTowers[1].GetComponentInChildren<TurretAI>().prix.ToString();
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        if (copieTower == null)
        {
            achat.SetActive(true);
        }
        else
        {
            if(copieTower.name.Contains("T3"))
                return;
            upgrade.GetComponentInChildren<TextMeshProUGUI>().text = turretScript.nextRank.GetComponentInChildren<TurretAI>().prix.ToString();
            upgrade.SetActive(true);
        }
        StartCoroutine(delay());
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(copieTower);
        }
    }

    public void PlaceTour(GameObject g)
    {
        int prix = g.GetComponentInChildren<TurretAI>().prix;
        if (GameManager.GM.money >= prix)
        {
            Destroy(copieTower);
            GameManager.GM.money -= prix;
            copieTower = Instantiate(g);
            copieTower.transform.position = transform.position;
            turretScript = copieTower.GetComponentInChildren<TurretAI>();
            copieTower.GetComponentInChildren<SphereCollider>().radius = turretScript.range;
        }
        else
        {
            StartCoroutine(delayMoney());
        }
        achat.SetActive(false);
        upgrade.SetActive(false);
    }

    public void upgradeTour()
    {        
        if(turretScript.level<turretScript.levelMax)
        {
            StartCoroutine(delayXP());
            return;
        }
        PlaceTour(turretScript.nextRank);
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
        achat.SetActive(false);
        upgrade.SetActive(false);
    }

    IEnumerator delayMoney()
    {
        moneyError.SetActive(true); // Enable the text so it shows
        print("saucisse");
        yield return new WaitForSeconds(2);
        moneyError.SetActive(false); // Disable the text so it shows
    }
    IEnumerator delayXP()
    {
        xpError.SetActive(true); // Enable the text so it shows
        print("jambon");
        yield return new WaitForSeconds(2);
        xpError.SetActive(false); // Disable the text so it shows
    }

    
}
