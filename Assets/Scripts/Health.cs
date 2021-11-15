using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    public int health = 100;

    Text Meter;

    // Start is called before the first frame update
    void Start()
    {
        Meter = GameObject.Find("Health_Text").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Death();
        }

        Meter.text = health.ToString();
    }

    void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
