using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    float lastShot;
    float atkSpd=0.2f;
    float range = 10;
    float shotSpd=1000;
    float dmg;

    public GameObject cible;
    
    public GameObject balle;

    // Start is called before the first frame update
    void Start()
    {
        lastShot = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject b;
        Vector3 dir;
        float currTime = Time.time;               
        if (cible == null) {return;}
        transform.LookAt(new Vector3(cible.transform.position.x, transform.position.y, cible.transform.position.z));
        if (currTime - lastShot > atkSpd)
        {
            lastShot = currTime;
            b = Instantiate(balle, transform.position, transform.rotation);
            b.GetComponent<Balle>().dmg = 1;
            b.transform.Translate(new Vector3(0, 0.7f, 0));
            dir = (cible.transform.position - b.transform.position).normalized;
            b.GetComponent<Rigidbody>().AddForce(dir * shotSpd);
            Destroy(b, 2);
        }
    }
}
