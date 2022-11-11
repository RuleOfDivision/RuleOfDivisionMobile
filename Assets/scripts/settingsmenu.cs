using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class settingsmenu : MonoBehaviour
{
    
    public AudioMixer AudioMixer;
    public Toggle fullScr;
    void Start()
    {
        fullScr.isOn = Screen.fullScreen;
    }

    public void SetSFXVOLUME(float sfxvolume)
    {
        AudioMixer.SetFloat("SFXVol", sfxvolume);
    }

    public void SetMusicVOLUME(float musVolume)
    {
        AudioMixer.SetFloat("MusicVol", musVolume);
    }

    public void SetVoiceVOLUME(float Voxvolume)
    {
        AudioMixer.SetFloat("VoiceVol", Voxvolume);
    }

    public void SetMasterVOLUME(float MasterVolume)
    {
        AudioMixer.SetFloat("MasterVol", MasterVolume);
    }
    /*
    public void SetFullscreen(bool isFullscreen)
    {
        Debug.Log("gaming");
        Screen.fullScreen = isFullscreen;
    }*/
}
