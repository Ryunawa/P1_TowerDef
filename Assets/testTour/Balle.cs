using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public int dmg;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject touche = collision.gameObject;
        if (touche.CompareTag("Ennemi"))
        {
            touche.GetComponent<Ennemi>().att(dmg);
            Destroy(gameObject);
        }
    }
}
