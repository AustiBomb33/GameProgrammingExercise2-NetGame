using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    //called when the object collides with another
    private void OnCollisionEnter2D(Collision2D other)
    {
        //check if 'other' is the net
        if (other.collider.gameObject.layer == 3)
        {
            //call NetController.Score()
            other.collider.gameObject.SendMessage("Score");
        }
        Destroy(gameObject);
    }
}
