using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class show_first_dialogue : MonoBehaviour
{//this is a dialogue class, our player talks by himself at the game start
    GameObject d,t;
    public TextMeshProUGUI textDisplay;
    public string s;
    void Start()
    {//we get text references
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        d.SetActive(true);
        StartCoroutine(Type());
        
    }

    IEnumerator Type()
    {
        s = "Me: Goodbye father, you will be remembered...";
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
        s = "Me: There's nothing left for me here, I should get going.";
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
        s = "Me: I should take my weapons, they are in the crate by the window inside the lake house.";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }



}
