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

    [SerializeField]
    GameObject Flash_Prefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject Flash = Instantiate(Flash_Prefab, transform.position, transform.rotation);
        Detonate();
        Destroy(gameObject);
    }

    void Detonate()
    {
        Collider2D[] Blast = Physics2D.OverlapCircleAll(transform.position, Radius);

        foreach (Collider2D Obj in Blast)
        {
            if (Obj.gameObject.tag == "Player")
            {
                Vector2 dir = Obj.transform.position - transform.position;
                Obj.transform.parent = null;
                Obj.transform.rotation = Quaternion.identity;
                Obj.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
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
