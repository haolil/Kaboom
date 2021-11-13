using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpReplenish : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.rigidbody.tag == "Ground" && collision.relativeVelocity.y >= 0f)
        {
            transform.GetComponent<PlayerController>().jumpCount = transform.GetComponent<PlayerController>().airJumpLimit + 1;
        }
    }
}
