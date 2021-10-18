using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public List<GameObject> towerList;
    GameObject copieTower;
    Canvas c;

    // Start is called before the first frame update
    void Start()
    {
        GetComponentInChildren<Canvas>().worldCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        c = GetComponentInChildren<Canvas>();
        c.enabled = false;
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
        if (copieTower == null)
        {
            copieTower = Instantiate(towerList[0]);
            copieTower.transform.position = transform.position;
            copieTower.GetComponentInChildren<SphereCollider>().radius = towerList[0].GetComponentInChildren<BasicAI>().range;
        }
        c.enabled = false;
    }

    public void PlaceCanon()
    {
        if (copieTower == null)
        {
            copieTower = Instantiate(towerList[1]);
            copieTower.transform.position = transform.position;
            copieTower.GetComponentInChildren<SphereCollider>().radius = towerList[0].GetComponentInChildren<BasicAI>().range;
        }
        c.enabled = false;
    }

}
