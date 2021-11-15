using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXCtl : MonoBehaviour
{

    [SerializeField] AudioSource sfxCtl;
    private float soundVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
        sfxCtl = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        sfxCtl.volume = soundVolume;
        SFXClick();
    }
    public void SFXClick()
    {
        // If the left mouse button is pressed down...
        if (Input.GetMouseButtonDown(0) == true)
        {
            GetComponent<AudioSource>().Play();
        }
        // If the left mouse button is released...
        if (Input.GetMouseButtonUp(0) == true)
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    public void SetVolume(float vol)
    {
        soundVolume = vol;
    }

}
