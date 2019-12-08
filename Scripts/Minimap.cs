using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minimap : MonoBehaviour
{
    public Transform player;

    void LateUpdate()//on lateupdate
    {
        Vector3 newPosition = player.position;//we get position of player
        newPosition.y = transform.position.y;//we change the y position of camera
        transform.position = newPosition;

        transform.rotation = Quaternion.Euler(90f, player.eulerAngles.y, 0f);//we rotate minimap camera accordingly
    }

   
}
