using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trigger_talk_harbor : MonoBehaviour
{//this is a trigger talk class for the harbor master
    public Animator anim;
    GameObject d, t;
    GameObject prize1, prize2, prize3, prize4;
    public TextMeshProUGUI textDisplay;
    public string s;
    public bool first,complete, firstc;

    void Start()
    {//we get his animetor component and object references through tags
        anim = GetComponent<Animator>();
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        prize1 = GameObject.FindGameObjectWithTag("prize1");
        prize2 = GameObject.FindGameObjectWithTag("prize2");
        prize3 = GameObject.FindGameObjectWithTag("prize3");
        prize4 = GameObject.FindGameObjectWithTag("prize4");
        first = true;//first time talking
        complete = false;//quest completed
        firstc = false;//first time talking after quest completion
    }


    private void OnTriggerStay(Collider other)
    {
        anim.SetTrigger("approach");
        if (!prize1.GetComponent<Renderer>().enabled && !prize2.GetComponent<Renderer>().enabled && !prize3.GetComponent<Renderer>().enabled)//if all prize objects are invisible
        {
            complete = true;//that means we have won them so quest is completed
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
        s = "Me: Hi there! I was told you have boats. Could you possibly lend me one and sail to the mainland?";
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
        s = "Harbor Master: I am sorry, without money you can't go anywhere.";
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
        s = "Harbor Master: But if you help three of our fellow citizens you may have your ride.";
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
        s = "Harbor Master: Help the blacksmith. the farmer and the soldier.";
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
        s = "Harbor Master: The blacksmith is by his forge. You can find it behind this place towards the village.";
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
        s = "Harbor Master: The farmer is at his farm. Go left from here and pass the river. He is at the second farm.";
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
        s = "Harbor Master: The soldier is at the castle. Go right from here and you will see its walls rising up.";
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
        s = "Me: All these will be done, you have my word!";
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
        s = "Harbor Master: Congratulations, you have completed your quest! Take this as a gift and now go at the edge of the pier and take a boat to the mainland!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        prize4.GetComponent<Renderer>().enabled = false;
    }

    IEnumerator Type3()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Harbor Master: Complete all three tasks and then you shall have your ride!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }

}
