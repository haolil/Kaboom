using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grounded : MonoBehaviour
{
    GameObject player;
    void Start()
    {
        player = transform.gameObject;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Spike" || collision.tag == "Saw")
        {
            player.GetComponent<PlayerController>().isGrounded = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Spike" || collision.tag == "Saw")
        {
            player.GetComponent<PlayerController>().isGrounded = false;
        }
    }
}
