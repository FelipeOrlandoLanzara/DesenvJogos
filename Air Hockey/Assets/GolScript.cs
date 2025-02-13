using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolScript : MonoBehaviour
{

    void OnTriggerEnter2D (Collider2D hitInfo) {
        if (hitInfo.tag == "Ball")
        {
            string wallName = transform.name;
            //GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }

}


