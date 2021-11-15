using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb_Throw : MonoBehaviour
{
    [SerializeField]
    Transform Spawn;

    [SerializeField]
    GameObject Bomb_Prefab;

    [SerializeField]
    float Speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Throw();
        }
    }

    void Throw()
    {
        GameObject Bomb = Instantiate(Bomb_Prefab, Spawn.position, Bomb_Prefab.transform.rotation);
        Rigidbody2D rb = Bomb.GetComponent<Rigidbody2D>();
        rb.AddForce(Spawn.right * Speed, ForceMode2D.Impulse);
    }
}
