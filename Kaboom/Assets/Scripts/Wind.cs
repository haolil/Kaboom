using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wind : MonoBehaviour
{
    Rigidbody2D rb;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    float Air_Speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-.5f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(.5f, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(transform.up * Air_Speed, ForceMode2D.Force);
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            rb.AddForce(transform.up * Air_Speed, ForceMode2D.Force);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Player.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        }
    }
}
