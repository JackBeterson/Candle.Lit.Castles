using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class settingScreen : MonoBehaviour
{
    public AudioMixer audioMixer;

    public void MusicVol (float mVolume)
    {
        audioMixer.SetFloat("musicVol", mVolume);
    }

    public void SoundVol (float sVolume)
    {
        audioMixer.SetFloat("soundVol", sVolume);
    }
}
