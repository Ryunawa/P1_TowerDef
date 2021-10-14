using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public List<GameObject> towerList;
    GameObject copieTower;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseDown()
    {
        if (copieTower == null)
        {
            copieTower = Instantiate(towerList[0]);
            copieTower.transform.position = transform.position;
            copieTower.transform.Translate(new Vector3(0, 0, 0));
            copieTower.GetComponentInChildren<SphereCollider>().radius = towerList[0].GetComponentInChildren<BasicAI>().range;
        }
        else
        {
            print(copieTower.GetComponentInChildren<BasicAI>().getStats());
        }
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Destroy(copieTower);
        }
    }
}
