using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trigger_talk_thief : MonoBehaviour
{//this is a trigger talk class for the thief
    public Animator anim;
    GameObject d, t, ale;
    public TextMeshProUGUI textDisplay;
    public string s;
    public bool first, done, p;
    public int punches;

    void Start()
    {//get thieve's animator component and object references through tags
        anim = GetComponent<Animator>();
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        ale = GameObject.FindGameObjectWithTag("ale");
        first = true;
        done = false;
        p = false;
        punches = 0;
    }


    private void OnTriggerStay(Collider other)//while in collider trigger area
    {
        if (first)
        {
            first = false;
            anim.SetTrigger("attack");//trigger attack which playes a punch animation
            StartCoroutine(Type1());
            
        }
        if (Input.GetButtonDown("Interact") && done && p)//if we have punched 3 times and the first dialogue is complete
        {
            p = false;
            StartCoroutine(Type2());
        }
        if (Input.GetMouseButtonDown(0) && punches !=10)//every time we punch 
        {
            punches = punches + 1;
        }

        if(punches == 10)//if we have punched 3 times
        {
            done = true;
            anim.SetTrigger("stop");//thief goes to idle
        }



    }

    IEnumerator Type1()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: You! Stop! I have come to retrieve what's stolen!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Thief: HA! Bring it on! Eat that!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        p = true;
    }

    IEnumerator Type2()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Thief: Oh... you have a strong arm, we didn't mean any harm, here that's what is left, take it!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        ale.GetComponent<Renderer>().enabled = false;
        yield return new WaitForSeconds(5.0f);
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: This ale stinks...";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);

    }

}
