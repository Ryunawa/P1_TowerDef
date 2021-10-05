using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{
    float lastShot;

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
        Vector3 dir =Vector3.RotateTowards(transform.forward, cible.transform.position - transform.position, 5*Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(dir);

        if (currTime - lastShot >1)
        {
            lastShot = currTime;
            b = Instantiate(balle);
            b.transform.position = transform.position;

            b.GetComponent<Rigidbody>().AddForce(dir*1000);
            Destroy(b, 2);
        }
    }
}
