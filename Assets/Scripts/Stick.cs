using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stick : MonoBehaviour
{
    Rigidbody2D rb;

    public bool stickable = true;
    public bool nomove = false;

    int Damage = 3;

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
        yield return new WaitForSeconds(1.5f);
    }

    void isStuck()
    {
        gameObject.GetComponent<Health>().health = gameObject.GetComponent<Health>().health - Damage;
        nomove = true;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        gameObject.transform.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        gameObject.transform.GetComponent<Rigidbody2D>().angularVelocity = 0;
    }

    void notStuck()
    {
        nomove = false;
        stickable = false;
        gameObject.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
        transform.parent = null;
        transform.rotation = Quaternion.identity;
        //rb.AddForce(transform.up * height, ForceMode2D.Impulse);
    }
}
