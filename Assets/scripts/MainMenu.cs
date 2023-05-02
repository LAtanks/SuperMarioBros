using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public GameObject MainMenuObj;
    public GameObject SettingsMenuObj;

    public TextMeshProUGUI master_;
    public TextMeshProUGUI sfx_;
    public TextMeshProUGUI music_;
    public AudioMixer AudioMixer;
    public AudioSource audioSource;
    public void StartBtn(){
        SceneManager.LoadScene("Kingdom1");
    }
    public void SettingsBtn(){
        MainMenuObj.SetActive(false);
        SettingsMenuObj.SetActive(true);
    }
    
    public void SetQualityGame(int lvl){
        QualitySettings.SetQualityLevel(lvl);
    }

    public void QuitGameBtn(){
        Application.Quit();
        Debug.Log("Quit Game");
    }

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
    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }
}
