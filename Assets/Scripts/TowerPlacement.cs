using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour
{
    public GameObject tower;
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
            copieTower = Instantiate(tower);
            copieTower.transform.position = transform.position;
            copieTower.transform.Translate(new Vector3(0, 0.6f, 0));
            copieTower.GetComponentInChildren<SphereCollider>().radius = tower.GetComponent<BasicAI>().range;
        }
        else
        {
            print(copieTower.GetComponent<BasicAI>().getStats());
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
