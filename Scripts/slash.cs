using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slash : MonoBehaviour
{
    public Animator anim;

    GameObject dc;
    

    void Start()
    {
        anim = GetComponent<Animator>();// i get the animator of my character
    }

    void Update()
    {
        dc = GameObject.FindGameObjectWithTag("DaggerCase");//get reference of weapon through tag
        if (Input.GetMouseButtonDown(0) && dc.GetComponent<Renderer>().enabled)//if i click right mouseclick and i have weapons
        {
            anim.SetTrigger("Attack");//i trigger Attack which is an animation of Attack
        }
    }
}
