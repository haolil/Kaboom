using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot_Bomb : MonoBehaviour
{
    Rigidbody2D rb;

    Vector2 Mouse_Pos;

    [SerializeField]
    GameObject Player;

    [SerializeField]
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.transform.position = Player.transform.position;
        Mouse_Pos = cam.ScreenToWorldPoint(Input.mousePosition);

        Vector2 AimDir = Mouse_Pos - rb.position;
        float Angle = Mathf.Atan2(AimDir.y, AimDir.x) * Mathf.Rad2Deg;

        rb.rotation = Angle;
    }
}
