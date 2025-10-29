using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class S_MainMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    public Slider musicSlider;
    public Slider sfxSlider;

    public void Start()
    {
        LoadVolume();
        S_MusicManager.Instance.PlayMusic("MainMenu");
        // Afficher le menu principal
        mainMenu.SetActive(true);
    }
    public void Play()
    {
        SceneManager.LoadScene("EstebanScene01");
        S_SoundManager.Instance.PlaySound3D("Menu_Validate", transform.position);
    }

    public void Options()
    {
        Debug.Log("Options menu n'est pas implémenté.");
        // Ne pas afficher le menu principal
        mainMenu.SetActive(false);
        S_SoundManager.Instance.PlaySound3D("Menu_Validate", transform.position);

    }
    
    public void Credits()
    {
        S_SoundManager.Instance.PlaySound3D("Menu_Validate", transform.position);
        SceneManager.LoadScene("Credits");
        // S_MusicManager.Instance.PlayMusic("Credits");

    }

    public void Quit()
    {
        S_SoundManager.Instance.PlaySound3D("Menu_Validate", transform.position);
        Application.Quit();
    }

    public void BackToMainMenu()
    {
        S_SoundManager.Instance.PlaySound3D("Menu_Validate", transform.position);
        // Afficher le menu principal
        mainMenu.SetActive(true);
        // Cacher le menu des options
        optionsMenu.SetActive(false);

    }

    public void UpdateMusicVolume(float volume)
    {
        audioMixer.SetFloat("MusicVolume", volume);
    }

    public void UpdateSFXVolume(float volume)
    {
        audioMixer.SetFloat("SFXVolume", volume);
    }

    public void SaveVolume()
    {
        audioMixer.GetFloat("MusicVolume", out float musicVolume);
        PlayerPrefs.SetFloat("MusicVolume", musicVolume);

        audioMixer.GetFloat("SFXVolume", out float sfxVolume);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFXVolume");
    }
}
