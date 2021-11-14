using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boom : MonoBehaviour
{
    [SerializeField]
    float Radius;

    [SerializeField]
    float Force;

    bool Detonated = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Detonated == true)
        {
            Distroy();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Detonate();
        Detonated = true;
    }

    IEnumerator Distroy()
    {
        Destroy(gameObject);
        yield return new WaitForSeconds(1f);
    }

    void Detonate()
    {
        Collider2D[] Blast = Physics2D.OverlapCircleAll(transform.position, Radius);

        foreach (Collider2D Obj in Blast)
        {
            if (Obj.gameObject.tag == "Player")
            {
                Vector2 dir = Obj.transform.position - transform.position;
                Obj.GetComponent<Rigidbody2D>().AddForce(dir * Force, ForceMode2D.Impulse);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, Radius);
    }
}
