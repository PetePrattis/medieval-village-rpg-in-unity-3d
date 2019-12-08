using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class trigger : MonoBehaviour
{   //this is the basic player trigger class

    GameObject g;
    GameObject m;
    GameObject dc;
    GameObject da;
    public GameObject i;

    public Animator anim;

    public TextMeshProUGUI textDisplay;
    public string s;
    GameObject d, t;
    GameObject dig;
    GameObject shield;
    GameObject finish;
    GameObject prize4;

    void Start()
    {//at start i find some game objects through tag reference and the textmesh pro text for interaction is hidden
        anim = GetComponent<Animator>();
        i = GameObject.FindGameObjectWithTag("interactd");
        i.SetActive(false);
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        dig = GameObject.FindGameObjectWithTag("dig");
        shield = GameObject.FindGameObjectWithTag("shield");
        finish = GameObject.FindGameObjectWithTag("finish");
        prize4 = GameObject.FindGameObjectWithTag("prize4");
    }

    public void OnTriggerEnter(Collider other)//once i enter a collider trigger area i show the text for interaction
    {

        i.SetActive(true);

    }

    private void OnTriggerStay(Collider other)//while i am inside the collider trigger area
    {

        if (Input.GetButtonDown("Interact"))//if i click the button E which is for interaction
        {
            if (other.gameObject.CompareTag("Crate"))//if the trigger collider object's tag is "Crate"
            {
                other.gameObject.SetActive(false);//i hide the closed crate
                g = GameObject.FindGameObjectWithTag("Crate_Open");
                g.GetComponent<Renderer>().enabled = true;//i show the open crate

                m = GameObject.FindGameObjectWithTag("Maul");//i get reference through tag of the player's gear
                dc = GameObject.FindGameObjectWithTag("DaggerCase");
                da = GameObject.FindGameObjectWithTag("Dagger");

                m.GetComponent<Renderer>().enabled = true;//i show player's gear
                dc.GetComponent<Renderer>().enabled = true;
                da.GetComponent<Renderer>().enabled = true;
                i.SetActive(false);
                StartCoroutine(Type1());//i call the StartCoroutine method Type1

            }
            else if (other.gameObject.CompareTag("dig") && dig.GetComponent<Renderer>().enabled)//if the trigger collider object's tag is "dig" and the rock is visible
            {
                anim.SetTrigger("dig");//i trigger dig, which plays a digging animation
                i.SetActive(false);//i hide the text for interaction
                //yield return new WaitForSeconds(2.0f);
                dig.GetComponent<Renderer>().enabled = false;//i hide the stone
                StartCoroutine(Type2());//i call the StartCoroutine method Type2
            }
            else if (other.gameObject.CompareTag("shield") && shield.GetComponent<Renderer>().enabled)//if the trigger collider object's tag is "shield" and the shield is visible
            {
                i.SetActive(false);
                //yield return new WaitForSeconds(2.0f);
                shield.GetComponent<Renderer>().enabled = false;// i hide the shield
                StartCoroutine(Type3());//i call the StartCoroutine method Type3
            }
            else if (other.gameObject.CompareTag("finish") && !prize4.GetComponent<Renderer>().enabled)//if the trigger collider object's tag is "finish" and the prize4 onject is invisible
            {
                i.SetActive(false);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                //yield return new WaitForSeconds(2.0f);
                SceneManager.LoadScene("Menu");//exit to main menu
            }
            else if (other.gameObject.CompareTag("finish") && prize4.GetComponent<Renderer>().enabled)//if the trigger collider object's tag is "finish" and the prize4 onject is visible
            {
                StartCoroutine(Type4());//i call the StartCoroutine method Type4
            }
        }

    }

    private void OnTriggerExit(Collider other)//when i leave the collider trigger area
    {
        i.SetActive(false);//i hide the interaction text
    }

    IEnumerator Type1()//every IEnumerator method that i use is to show dialogue text with typing effect
    {
        yield return new WaitForSeconds(2.0f);
        t.GetComponent<TextMeshProUGUI>().text = "";//dialogue text is empty
        d.SetActive(true);
        s = "Me: Now I should leave, I must follow the road behind my house, that leads to the village.";
        foreach (char letter in s.ToCharArray())//for every letter
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;//i show each letter with a small delay creating a typing effect
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }

    IEnumerator Type2()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: Doesn't seem special to me...";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }

    IEnumerator Type3()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: What a piece of junk!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }

    IEnumerator Type4()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: I can't leave just yet!";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }
}
