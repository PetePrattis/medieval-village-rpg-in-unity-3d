using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour
{

    public Transform player; //exposed variable for tha player
    static Animator anim;
    // Use this for initialization
    void Start()
    {

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        //if within set distance adn vision sapn turn towards player
        Vector3 direction = player.position - this.transform.position;

        //angle between forward diraction of npc and player
        float angle = Vector3.Angle(direction, this.transform.forward);

        //test for the distance between the players poston and the npc's position
        if (Vector3.Distance(player.position, this.transform.position) < 10 && angle < 30)
        {

            //so that the npc does not rotate upwards
            direction.y = 0;

            //rotate with a slurp = slowly
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation,
                Quaternion.LookRotation(direction), 0.1f);

            anim.SetBool("isIdle", false);
            if (direction.magnitude > 1.0f)
            {
                //npc starts moving forward
                this.transform.Translate(0, 0, 0.03f);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
            }
            else
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
            }
        }
        else
        {
            anim.SetBool("isIdle", true);
            anim.SetBool("isWalking", false);
            anim.SetBool("isAttacking", false);
        }
    }
}