using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetController : MonoBehaviour
{
    private float moveSpeed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveDir = Input.GetAxis("Horizontal");
        if((moveDir < 0 && transform.position.x > -7.6) ||(moveDir > 0 && transform.position.x < 7.6))
        {
            transform.position = new Vector3(transform.position.x + moveDir * moveSpeed * Time.deltaTime, transform.position.y);
        }
    }
}
