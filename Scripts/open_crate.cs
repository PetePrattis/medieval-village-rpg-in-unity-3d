using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class open_crate : MonoBehaviour
{
    
    void Start()//on start the open crate object is invisible
    {
        gameObject.GetComponent<Renderer>().enabled = false;
    }

}
