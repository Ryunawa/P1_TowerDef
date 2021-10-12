using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayonTour : MonoBehaviour
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
            GetComponentInParent<BasicAI>().ciblePossible.Add(other.gameObject);
    }
    private void OnTriggerExit(Collider other)
    {
        GetComponentInParent<BasicAI>().ciblePossible.Remove(other.gameObject);
    }


}
