using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        //check if 'other' is the net
        if (other.collider.gameObject.layer == 3)
        {
            //Call NetController.GameOver()
            other.collider.gameObject.BroadcastMessage("GameOver");
        }
        Destroy(gameObject);
    }
}
