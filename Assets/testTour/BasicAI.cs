using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    float lastShot;
    float atkSpd=0.2f;
    float range;
    float shotSpd=2500;
    float dmg;

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
        GameObject cible;
        float currTime = Time.time;
        cible = GameObject.FindGameObjectWithTag("Ennemi");
        if(cible == null) { return; }
        transform.LookAt(new Vector3(cible.transform.position.x,transform.position.y,cible.transform.position.z));
        if (currTime - lastShot >atkSpd)
        {
            lastShot = currTime;
            b = Instantiate(balle, transform.position,transform.rotation);
            b.GetComponent<Balle>().dmg = 1;
            b.GetComponent<Rigidbody>().AddForce(transform.forward*shotSpd);
            Destroy(b, 5);
        }
    }


}
