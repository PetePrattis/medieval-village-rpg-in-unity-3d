using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trigger_talk_smith : MonoBehaviour
{//this is a trigger talk class for the blacksmith
    public Animator anim;
    GameObject d, t;
    GameObject dig, prize1;
    public TextMeshProUGUI textDisplay;
    public string s;
    public bool first, complete, firstc;

    void Start()
    {//get blacksmith's animator component and object references through tags
        anim = GetComponent<Animator>();
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        dig = GameObject.FindGameObjectWithTag("dig");
        prize1 = GameObject.FindGameObjectWithTag("prize1");
        first = true;
        complete = false;
        firstc = false;
    }


    private void OnTriggerStay(Collider other)//while in collider trigger area
    {
        anim.SetTrigger("approach");//trigger approach which playes a waving hand animation
        if (!dig.GetComponent<Renderer>().enabled)//if stone object is invisible
        {
            complete = true;//quest is completed
            first = false;//even if we haven't talked to the harbor master we will not initiate the first dialog
        }

        if (Input.GetButtonDown("Interact"))
        {
            if (first)
            {
                anim.SetTrigger("talk");
                first = false;
                StartCoroutine(Type1());
            }
            else if (complete && !firstc)
            {
                anim.SetTrigger("talk");
                if (!firstc)
                    StartCoroutine(Type2());

                firstc = true;
            }
            else if (!first && !complete)
            {
                anim.SetTrigger("talk");
                if (!firstc)
                    StartCoroutine(Type3());
            }
        }

    }

    IEnumerator Type1()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: Hi, the Harbor Master sent me. Is there anything I can help you with?";
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
        s = "Blacksmith: Oh hi! I have heard that there is a special metal at the river's fountain. Dig at the river's source and bring it to me. You will be rewarded!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }

    IEnumerator Type2()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Blacksmith: Nice, nice! This will do! Here, take your prize.";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        prize1.GetComponent<Renderer>().enabled = false;

    }

    IEnumerator Type3()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Blacksmith: What are you still doing here? Get going!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);

    }
}
