using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trigger_talk_plant : MonoBehaviour
{//this is a trigger talk class for the farmer
    public Animator anim;
    GameObject d, t;
    GameObject shield, prize2;
    public TextMeshProUGUI textDisplay;
    public string s;
    public bool first, complete, firstc;

    void Start()
    {//get farmer's animator component and object references through tags
        anim = GetComponent<Animator>();
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        shield = GameObject.FindGameObjectWithTag("shield");
        prize2 = GameObject.FindGameObjectWithTag("prize2");
        first = true;
        complete = false;
        firstc = false;
    }


    private void OnTriggerStay(Collider other)//while in collider trigger area
    {
        anim.SetTrigger("approach");//trigger approach which playes an idle animation
        if (!shield.GetComponent<Renderer>().enabled)//if shield object is invisible
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
        s = "Me: Hello! I was sent by the Harbor Master to help.";
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
        s = "Farmer: You don't look like a farmer to me, but you may still be useful!";
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
        s = "Farmer: Continue up that road towards the forest, after a while you will find some old ruins. There lies my grandfather's shield, bring it back to me.";
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
        s = "Farmer: Still in good condition... it will fetch a few coins. Here, you deserve this prize!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        prize2.GetComponent<Renderer>().enabled = false;

    }

    IEnumerator Type3()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Farmer: You haven't brought the shield! Please go get it!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);

    }
}
