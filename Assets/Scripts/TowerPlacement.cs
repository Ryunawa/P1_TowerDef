using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public List<GameObject> towerList;
    GameObject copieTower;
    public GameObject moneyError;
    Canvas c;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        c = GetComponentInChildren<Canvas>();
        c.enabled = false;
        moneyError.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (copieTower == null)
        {
            c.enabled = true;
        }
        else
        {
            print(copieTower.GetComponentInChildren<TurretAI>().getStats());
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(copieTower);
        }
    }

    public void PlaceBaliste()
    {
        if (copieTower == null && GameManager.GM.money >= 30)
        {
            GameManager.GM.money -= 30;
            copieTower = Instantiate(towerList[0]);
            copieTower.transform.position = transform.position;
            copieTower.GetComponentInChildren<SphereCollider>().radius = towerList[0].GetComponentInChildren<TurretAI>().range;
        }
        else
        {
            moneyError.SetActive(true); // Enable the text so it shows
            print("pas assez d'argent");
            delay();
            moneyError.SetActive(false); // Disable the text so it shows
        }
        c.enabled = false;
    }

    public void PlaceCanon()
    {
        if (copieTower == null && GameManager.GM.money >= 50)
        {
            GameManager.GM.money -= 50;
            copieTower = Instantiate(towerList[1]);
            copieTower.transform.position = transform.position;
            copieTower.GetComponentInChildren<SphereCollider>().radius = towerList[0].GetComponentInChildren<TurretAI>().range;
        }
        c.enabled = false;
    }

    IEnumerator delay()
    {
        yield return new WaitForSeconds(5);
    }
}
