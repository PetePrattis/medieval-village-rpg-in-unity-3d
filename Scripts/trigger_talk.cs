using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trigger_talk : MonoBehaviour
{//this is the trigger talk class for the villager at the village's wooden gate

    public Animator anim;
    GameObject dc;
    GameObject d, t;
    public TextMeshProUGUI textDisplay;
    public string s;
    public bool first;

    void Start()
    {
        anim = GetComponent<Animator>();//i get the villager's animator
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        first = true;
    }


    private void OnTriggerStay(Collider other)//while i am inside the collider trigger area
    {
        anim.SetTrigger("approach");//i trigger the approach which playes a waving hand animation
        if (Input.GetButtonDown("Interact") && first)//if i click E for interaction
        {
            anim.SetTrigger("talk");//i trigger the talk which playes a talking animation
            if (first)
            {
                first = false;//first time speaking to villager is no longer true
                StartCoroutine(Type());//i call the StartCoroutine method Type
            }
        }
        
            
    }
    IEnumerator Type()//every IEnumerator method that i use is to show dialogue text with typing effect
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Stranger: Hi there! Our village is just begind this valley. Welcome!";
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
        s = "Me: Thank you...";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        yield return new WaitForSeconds(5.0f);
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: I may be able to find information at the village tavern.";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }
}

