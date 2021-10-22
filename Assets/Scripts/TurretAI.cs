using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAI : MonoBehaviour
{
    float lastShot;
    float atkSpd=0.2f;
    public float range = 3;
    float shotSpd=1000;
    public float dmg;
    public int peircing;

    public int level = 0;
    public int levelMax = 3;
    int xp = 0;
    int xpmax = 20;

    public int prix;

    public List<GameObject> ciblePossible = new List<GameObject>();

    GameObject cible;
    
    public GameObject balle;
    public GameObject soundEffect;
    public GameObject nextRank;

    // Start is called before the first frame update
    void Start()
    {
        lastShot = Time.time;
        foreach(Collider c in Physics.OverlapSphere(transform.position, range,1<<7))
        {
            ciblePossible.Add(c.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        GameObject b;
        Bullet composant;
        Vector3 dir;
        float currTime = Time.time;

        while (ciblePossible.Count > 0 && ciblePossible[0] == null) //enlève les cibles détruites
            ciblePossible.RemoveAt(0);

        if (ciblePossible.Count == 0) // quitte si aucune si à portée
            return;

        cible = ciblePossible[0];
        transform.LookAt(new Vector3(cible.transform.position.x, transform.position.y, cible.transform.position.z)); //tourne la tour vers sa cible
        
        if (currTime - lastShot > atkSpd) // tir si suffisement de temps est passé depuis le dernier
        {
            Instantiate(soundEffect);
            lastShot = currTime;
            b = Instantiate(balle, transform.position, transform.rotation); // crée le projectile et lui assigne ses variables
            composant = b.GetComponent<Bullet>();
            composant.dmg = dmg;
            composant.parentTower = gameObject;
            composant.peircing = peircing;
            b.transform.Translate(new Vector3(0, 0.3f, 0));
            b.transform.LookAt(cible.transform.position);
            dir = (cible.transform.position - b.transform.position).normalized; //tir le projectile vers sa cible
            b.GetComponent<Rigidbody>().AddForce(dir * shotSpd);
            Destroy(b, 1); // détruit le projetile dans 1s pour éviter de remplir la mémoire
        }
    }

    public void addXP(int i) //gagne de l'xp et éventuellement monte de niveau
    {
        xp += i;
        if (xp >= xpmax && level < levelMax)
        {
            level++;
            xp -= xpmax;
            xpmax *= 2;
            atkSpd /= 1.01f;
            dmg *= 1.1f;
        }
    }

    public string getStats() //renvoie un string des stats de la tour, utilisé pour debugger
    {
        string res = "Niveau : " + level + "\n"
            + "XP : "+ xp + "\n"
            + "D�gats : " + dmg + "\n" 
            + "Vitesse d'attaque : " + atkSpd;
        return res;
    }

}
