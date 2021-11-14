using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRocket : MonoBehaviour
{
    public float rocketForce;
    public float rocketDamage;
    public float fieldOfImpact;
    public LayerMask layerToHit;
    Transform radius;
    // Start is called before the first frame update
    void Start()
    {
        radius = transform.GetChild(0);
        radius.localScale = new Vector3(fieldOfImpact*4, fieldOfImpact*4, 0);
    }

    // Update is called once per frame
    void Update()
    {
        RocketControl();
    }

    public void RocketControl()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RocketExplosion();
            Destroy(gameObject);
        }
    }

    public void RocketExplosion()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, fieldOfImpact, layerToHit);
        foreach(Collider2D obj in objects)
        {
            print(obj.name);
            Vector2 direction = obj.transform.position - transform.position;
            obj.GetComponent<Rigidbody2D>().AddForce(direction * rocketForce);
            RocketDamage(obj.gameObject);

        }
    }

    public void RocketDamage(GameObject player)
    {
        if (player.GetComponent<PlayerController>())
        {
            player.GetComponent<PlayerController>().takenDamage = rocketDamage;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, fieldOfImpact);
    }
}
