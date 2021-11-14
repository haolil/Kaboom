using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzsaw : MonoBehaviour
{
    [SerializeField]
    int Speed;

    public int Damage = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, -Speed * Time.deltaTime);
    }
}
