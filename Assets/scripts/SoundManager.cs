using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public AudioMixer AudioMixer;
    public AudioSource audioSource;

    public void SetClickEffect(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
    public void SetSfxLvl(float lvl)
    {
        AudioMixer.SetFloat("sfx", lvl);
    }
    public void SetMusicLvl(float lvl)
    {
        AudioMixer.SetFloat("music", lvl);
    }
    public void SetMasterLvl(float lvl)
    {
        AudioMixer.SetFloat("master", lvl);
    }

}
