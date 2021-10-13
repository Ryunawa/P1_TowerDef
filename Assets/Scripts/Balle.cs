using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balle : MonoBehaviour
{
    public int dmg;
    public GameObject parentTower;
    public int type;
    public float rayon = 1;

    Collider[] CiblePossible;

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
        switch (type)
        {
            case 1:
                if (touche.CompareTag("Ennemi"))
                {
                    touche.GetComponent<EnemyHealth>().DealtDamage(dmg);
                    parentTower.GetComponent<BasicAI>().addXP(1); 
                }
                break;

            case 2:
                CiblePossible = Physics.OverlapSphere(transform.position, rayon);
                foreach(Collider c in CiblePossible)
                {
                    if (c.CompareTag("Ennemi"))
                    {

                        c.GetComponent<EnemyHealth>().DealtDamage(dmg);
                        parentTower.GetComponent<BasicAI>().addXP(1);
                    }
                }
                break;
            default:
                break;
        }
        Destroy(gameObject);
    }
}
