using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Instantiate : MonoBehaviour {
    
    public Player ip;

    public void wumpinit(GameObject pfab)
    {
        Instantiate(pfab, new Vector3(0,0,2),  Quaternion.identity);
    }
    public void batinit(GameObject pfab)
    {
        Instantiate(pfab, new Vector3(0, 0, 2), Quaternion.identity);

    }
    public void holeinit(GameObject pfab)
    {
        Instantiate(pfab, new Vector3(0, 0, -1.5f), Quaternion.identity);
        pfab.GetComponent<Hole>().t = GameObject.FindWithTag("TriviaManager").GetComponent<TriviaManager>();
        pfab.GetComponent<Hole>().m = GameObject.FindWithTag("MobManager").GetComponent<MobManager>();
        pfab.GetComponent<Hole>().p = GameObject.FindWithTag("Player").GetComponent<Player>();

    }
}
