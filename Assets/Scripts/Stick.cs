using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Rigidbody2D rb;

    public bool stickable = true;

    [SerializeField]
    float height;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (stickable == false)
        {
            StartCoroutine(stick());
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            notStuck();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (stickable == true && 
            other.gameObject.tag == "Spike" ||
            other.gameObject.tag == "Saw")
        {
            transform.parent = other.transform;
            isStuck();
        }
    }

    IEnumerator stick()
    {
        stickable = true;
        yield return new WaitForSeconds(1f);
    }

    void isStuck()
    {
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
    }

    void notStuck()
    {
        stickable = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        transform.parent = null;
        rb.AddForce(transform.up * height, ForceMode2D.Impulse);
    }
}
