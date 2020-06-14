using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    //public Toggle res2;
    //public Toggle res3;

    private void Start()
    {
        /*
        switch(Screen.currentResolution.height)
        {
            case 1920:
                res3.isOn = true;
                res2.isOn = false;
                break;
            case 1420:
                res2.isOn = true;
                res3.isOn = false;
                break;
            default:
                break;
        }  */    
    }

    private void Update()
    {
        /*
        switch (Screen.currentResolution.height)
        {
            case 1920:
                res3.isOn = true;
                res2.isOn = false;
                break;
            case 1420:
                res2.isOn = true;
                res3.isOn = false;
                break;
            default:
                break;
        } */
    }

    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    
    public void SetFullscreen (bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void SetResolutionOne (bool isSet)
    {
        Screen.SetResolution(1024, 800, false); //false means it is windowed
    }

    public void SetResolutionTwo(bool isSet)
    {
        Screen.SetResolution(1420, 960, false); //false means it is windowed
    }

    public void SetResolutionThree(bool isSet)
    {
        Screen.SetResolution(1920, 1080, false); //false means it is windowed
    }
}
