using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weapons_start : MonoBehaviour
{
    GameObject m;
    GameObject dc;
    GameObject d;
    GameObject i;

    
    void Start()//on start the weapons on main character are invisible
    {
        m = GameObject.FindGameObjectWithTag("Maul");
        dc = GameObject.FindGameObjectWithTag("DaggerCase");
        d = GameObject.FindGameObjectWithTag("Dagger");
        i = GameObject.FindGameObjectWithTag("interactd");


        m.GetComponent<Renderer>().enabled = false;
        dc.GetComponent<Renderer>().enabled = false;
        d.GetComponent<Renderer>().enabled = false;
    }
}
