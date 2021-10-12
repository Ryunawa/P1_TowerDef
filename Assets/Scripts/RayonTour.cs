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

    
    private void OnTriggerStay(Collider other)
    {
        GameObject newTarget = other.gameObject;
        
        if ( newTarget.CompareTag("Ennemi") && (GetComponentInParent<BasicAI>().cible == null || GetComponentInParent<BasicAI>().cible.GetComponent<RoadToGoal>().agent.remainingDistance > newTarget.GetComponent<RoadToGoal>().agent.remainingDistance))
        {
            GetComponentInParent<BasicAI>().cible = newTarget;
        }   
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject == GetComponentInParent<BasicAI>().cible)
        {
            GetComponentInParent<BasicAI>().cible = null;
        }
    }
}
