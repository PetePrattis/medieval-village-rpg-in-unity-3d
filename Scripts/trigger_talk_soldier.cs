using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trigger_talk_soldier : MonoBehaviour
{//this is the trigger talk class for the soldier
    public Animator anim;
    GameObject d, t;
    GameObject ale, prize3;
    public TextMeshProUGUI textDisplay;
    public string s;
    public bool first, complete, firstc;

    void Start()
    {
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        ale = GameObject.FindGameObjectWithTag("ale");
        prize3 = GameObject.FindGameObjectWithTag("prize3");
        first = true;//first time talking
        complete = false;//quest completed
        firstc = false;//first time talking after quest completion
    }


    private void OnTriggerStay(Collider other)
    {
        if (!ale.GetComponent<Renderer>().enabled)//is the object with tag reference ale is invisible
        {
            complete = true;//this means tha tquest is complete
            first = false;//even if we haven't talked to the soldier we will not initiate the first dialogue
        }

        if (Input.GetButtonDown("Interact"))//if i press E for interaction
        {
            if (first)
            {
                first = false;
                StartCoroutine(Type1());
            }
            else if (complete && !firstc)
            {
                if (!firstc)
                    StartCoroutine(Type2());

                firstc = true;
            }
            else if (!first && !complete)
            {
                if (!firstc)
                    StartCoroutine(Type3());
            }
        }

    }

    IEnumerator Type1()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: Greetings! The harbor Master sent me. May I be of assistance?";
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
        s = "Soldier: Hmmm... You are not one of those thieves! Yes, you can help. Go and face the thieves that stole and drunk our ale!";
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
        s = "Soldier: You can find them at their camp after the stone bridge. Just get out of the castle and go right.";
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
        s = "Soldier: Aha, so you faced them and you brought back some ale! You have earned this prize!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        prize3.GetComponent<Renderer>().enabled = false;

    }

    IEnumerator Type3()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Soldier: Did you lose your nerve? Do you have second thoughts? Just go!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);

    }
}
