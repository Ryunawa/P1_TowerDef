using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ennemi : MonoBehaviour
{
    int hp = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void att(int i)
    {
        hp -= i;
        print(hp);
        if (hp <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
