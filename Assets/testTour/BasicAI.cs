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
        transform.LookAt(cible.transform);
        //transform.rotation = Quaternion.LookRotation(dir);
        print(cible.transform.position);
        if (currTime - lastShot >0.2f)
        {
            lastShot = currTime;
            b = Instantiate(balle);
            b.transform.position = transform.position;
            b.transform.position = new Vector3(b.transform.position.x + Mathf.Sin(transform.rotation.y)/(2*Mathf.PI), b.transform.position.y, b.transform.position.z + Mathf.Cos(transform.rotation.y) / (2 * Mathf.PI));
            b.GetComponent<Rigidbody>().AddForce(transform.forward*500);
            Destroy(b, 4);
        }
    }
}
