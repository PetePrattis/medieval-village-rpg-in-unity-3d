using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class trigger_talk_shady : MonoBehaviour
{//this is a trigger talk class for the thief inside the village tavern
    GameObject d, t;
    public TextMeshProUGUI textDisplay;
    public string s;
    public bool first;

    void Start()
    {
        d = GameObject.FindGameObjectWithTag("dialogue");
        t = GameObject.FindGameObjectWithTag("text");
        first = true;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetButtonDown("Interact") && first)
        {
            first = false;
            StartCoroutine(Type());
        }


    }
    IEnumerator Type()
    {
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Me: Hi stranger, do you know if there's a way out of this island?";
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
        s = "Shady Individual: Between you and me, the only way to leave this place is through sea! So I would ask the harbor master.";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
        yield return new WaitForSeconds(2.0f);
        d.SetActive(true);
        t.GetComponent<TextMeshProUGUI>().text = "";
        s = "Shady Individual: Go behind  the tavern and walk towards the sea, you will see him...";
        foreach (char letter in s.ToCharArray())
        {
            t.GetComponent<TextMeshProUGUI>().text += letter;
            yield return new WaitForSeconds(0.02f);
        }
        yield return new WaitForSeconds(2.0f);
        d.SetActive(false);
    }
}
