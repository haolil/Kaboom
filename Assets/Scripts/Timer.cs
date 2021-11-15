using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    Text Minutes;
    Text Seconds;

    [SerializeField]
    int Base_Min;
    [SerializeField]
    int Base_Sec;

    float Min;
    float Sec;

    bool Start_Timer = true;

    // Start is called before the first frame update
    void Start()
    {
        Minutes = GameObject.Find("Minutes").GetComponent<Text>();
        Seconds = GameObject.Find("Seconds").GetComponent<Text>();
        Min = Base_Min;
        Sec = Base_Sec;
    }

    // Update is called once per frame
    void Update()
    {
        if (Min <= 0 && Sec <= 0)
        {
            Level_Reset();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset_Timer();
        }

        if (Start_Timer == true && Sec > 0)
        {
            Sec = Sec - 1 * Time.deltaTime;
        }

        if (Start_Timer == true && Sec <= 0 && Min != 0)
        {
            Sec = 60;
            Min--;
        }

        if (Start_Timer == true && Sec <= 0 && Min <= 0)
        {
            Start_Timer = false;
        }

        Minutes.text = "0" + Min.ToString();

        if (Sec < 10)
        {
            Seconds.text = "0" + Sec.ToString("F0");
        }
        else
        {
            Seconds.text = Sec.ToString("F0");
        }
    }

    public void Reset_Timer()
    {
        Min = Base_Min;
        Sec = Base_Sec;

        Start_Timer = true;
    }

    void Level_Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
