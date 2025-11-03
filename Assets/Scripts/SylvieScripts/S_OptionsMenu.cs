using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using TMPro;

public class S_OptionsMenu : MonoBehaviour
{
    public Slider musicVolumeSlider, sfxVolumeSlider;
    public AudioMixer mainAudioMixer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        LoadVolume();
    }

    // Update is called once per frame
    private void Update()
    {

    }

    public void ChangeMusicVolume()
    {
        float volume = musicVolumeSlider.value;
        mainAudioMixer.SetFloat("MusicVolume", musicVolumeSlider.value);
    }

    public void ChangeSFXVolume()
    {
        float volume = sfxVolumeSlider.value;
        mainAudioMixer.SetFloat("SFXVolume", sfxVolumeSlider.value);
    }

    public void SaveVolume()
    {
        mainAudioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        mainAudioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        musicVolumeSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolumeSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
