using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Transform player;
    public GameObject rocket;
    public float rocketSpeed;
    public Transform firepoint;
    public Transform rotatepoint;
    public float health;
    public float takenDamage;
    public float movementSpeed;
    public float jumpForce;
    public bool isGrounded;
    public int jumpCount;
    public int airJumpLimit;
    Vector2 lookDirection;
    float lookAngle;
    float xMovement;

    // Start is called before the first frame update
    void Start()
    {
        if(this.transform.GetComponent<PlayerController>() && this.transform.GetComponent<Rigidbody2D>())
        {
            player = this.transform;
            rotatepoint = player.GetChild(0);
            firepoint = rotatepoint.GetChild(0);

            health = 100;
        }
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        JumpCheck();
        HealthDecrease();
        PlayerDeath();
        TrackMouse();
        SpawnRocket();
    }

    public void HorizontalMovement()
    {
        xMovement = Input.GetAxis("Horizontal") * movementSpeed;

        player.position += new Vector3(xMovement, 0, 0) * Time.deltaTime;
    }

    public void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            player.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpForce;
            jumpCount--;
        }

    }

    public void JumpCheck()
    {
        if (isGrounded && jumpCount > 0)
        {
            Jump();
        }

            
    }

    public void HealthDecrease()
    {
        if (takenDamage > 0 && health != 0)
        {
            health -= takenDamage;
            print(health);
            takenDamage = 0;
        }else if(takenDamage > health)
        {
            health = 0;
            takenDamage = 0;
        }
    }

    public void PlayerDeath()
    {
        if(health == 0)
        {
            Destroy(player.gameObject);
        }
    }

    public void SpawnRocket()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GameObject rocketClone = Instantiate(rocket);
            rocketClone.transform.position = firepoint.position;
            rocketClone.transform.rotation = Quaternion.Euler(0, 0, lookAngle);
            rocketClone.GetComponent<Rigidbody2D>().velocity = firepoint.right * rocketSpeed;
        }
    }

    public void TrackMouse()
    {
        lookDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - rotatepoint.position;
        lookAngle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;

        rotatepoint.rotation = Quaternion.Euler(0, 0, lookAngle);
    }

}
