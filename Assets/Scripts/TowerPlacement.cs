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
        copieTower = Instantiate(tower);
        copieTower.transform.position = transform.position;

        print("Tourelle cr��e !");
    }

}
