using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerRange : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Ennemi"))
            GetComponentInParent<TurretAI>().ciblePossible.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<TurretAI>().ciblePossible.Remove(other.gameObject);
    }


}
