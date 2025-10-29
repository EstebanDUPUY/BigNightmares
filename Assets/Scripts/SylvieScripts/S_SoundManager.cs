using UnityEngine;



public class S_SoundManager : MonoBehaviour
{
    public static S_SoundManager Instance;

    [SerializeField] private S_SoundLibrary sfx2DLibrary;
    [SerializeField] private AudioSource sfx2DSource;

    private void Awake()
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

    public void PlaySound3D(AudioClip clip, Vector3 pos)
    {
        if (clip != null)
        {
            AudioSource.PlayClipAtPoint(clip, pos);
        }
    }

    public void PlaySound3D(string soundName, Vector3 pos)
    {
        PlaySound3D(sfx2DLibrary.GetClipFromName(soundName), pos);
    }

    public void PlaySound2D(string soundName)
    {
    
        sfx2DSource.PlayOneShot(sfx2DLibrary.GetClipFromName(soundName));
    }

}
