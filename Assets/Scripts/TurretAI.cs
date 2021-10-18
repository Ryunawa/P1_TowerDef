using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    float lastShot;
    float atkSpd=0.2f;
    public float range = 3;
    float shotSpd=1000;
    float dmg = 10;
    int peircing=0;

    int level = 0;
    int xp = 0;
    int xpmax = 20;

    public List<GameObject> ciblePossible = new List<GameObject>();

    GameObject cible;
    
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
        Bullet composant;
        Vector3 dir;
        float currTime = Time.time;

        while (ciblePossible.Count > 0 && ciblePossible[0] == null)
            ciblePossible.RemoveAt(0);

        if (ciblePossible.Count == 0)
            return;

        cible = ciblePossible[0];
        transform.LookAt(new Vector3(cible.transform.position.x, transform.position.y, cible.transform.position.z));
        
        if (currTime - lastShot > atkSpd)
        {
            lastShot = currTime;
            b = Instantiate(balle, transform.position, transform.rotation);
            composant = b.GetComponent<Bullet>();
            composant.dmg = dmg;
            composant.parentTower = gameObject;
            composant.type = 2;
            composant.peircing = peircing;
            b.transform.Translate(new Vector3(0, 0.6f, 0));
            b.transform.LookAt(cible.transform.position);
            dir = (cible.transform.position - b.transform.position).normalized;
            b.GetComponent<Rigidbody>().AddForce(dir * shotSpd);
            Destroy(b, 1);
        }
    }

    public void addXP(int i)
    {
        xp += i;
        if (xp == xpmax)
        {
            level++;
            xpmax *= 2;
            xp = 0;
            atkSpd /= 1.01f;
            dmg *= 1.1f;
        }
    }

    public string getStats()
    {
        string res = "Niveau : " + level + "\n"
            + "XP : "+ xp + "\n"
            + "Dégats : " + dmg + "\n" 
            + "Vitesse d'attaque : " + atkSpd;
        return res;
    }
}
