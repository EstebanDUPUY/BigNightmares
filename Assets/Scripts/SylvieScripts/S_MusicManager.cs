using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class S_MusicManager : MonoBehaviour
{
    public static S_MusicManager Instance;

    [SerializeField] private S_MusicLibrary musicLibrary;
    [SerializeField] private AudioSource musicSource;

    public void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void PlayMusic(string trackName)
    {
        AudioClip clipToPlay = musicLibrary.GetClipFromName(trackName);
        if (clipToPlay != null)
        {
            StartCoroutine(AnimateMusicCrossfade(clipToPlay, fadeDuration : 0.5f));
        }
    }

    IEnumerator AnimateMusicCrossfade(AudioClip nextTrack, float fadeDuration = 0.5f)
    {
        float percent = 0f;
        while (percent < 1)
        {
            percent += Time.deltaTime / fadeDuration;
            musicSource.volume = Mathf.Lerp(1f, 0f, percent);
            yield return null;
        }

        musicSource.clip = nextTrack;
        musicSource.Play();

        percent = 0f;
        while (percent < 1)
        {
            percent += Time.deltaTime / fadeDuration;
            musicSource.volume = Mathf.Lerp(0f, 1f, percent);
            yield return null;
        }
    }
}
