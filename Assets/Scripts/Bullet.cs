using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float dmg;
    public GameObject parentTower;
    public int type;
    public float rayon = 1;
    public int peircing;

    public GameObject part;

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

                    touche.GetComponent<EnemyBehaviour>().DealtDamage(dmg);
                    if(parentTower!= null)
						parentTower.GetComponent<TurretAI>().addXP(1); 
                }
                break;

            case 2:
                Instantiate(part);
                part.transform.position = transform.position;
                CiblePossible = Physics.OverlapSphere(transform.position, rayon);
                foreach(Collider c in CiblePossible)
                {
                    if (c.CompareTag("Ennemi"))
                    {

                        c.GetComponent<EnemyBehaviour>().DealtDamage(dmg);
                        if(parentTower!= null)
							parentTower.GetComponent<TurretAI>().addXP(1);
                    }
                }
                Destroy(gameObject);
                break;
            default:
                break;
        }
        peircing--;
        if (peircing <= 0)
        {
            Destroy(gameObject);
        }
    }
}
