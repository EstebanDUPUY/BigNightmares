using UnityEngine;



public class S_SoundManager : MonoBehaviour
{
    public static S_SoundManager Instance;

    [SerializeField] private S_SoundLibrary sfx2DLibrary;
    [SerializeField] public AudioSource sfx2DSource;

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
                // Destroy(clip);
            }
        }
 

    public void PlaySound3D(string soundName, Vector3 pos)
    {
        PlaySound3D(sfx2DLibrary.GetClipFromName(soundName), pos);
    }

    public void PlaySound2D(AudioClip soundName)
    {

        sfx2DSource.clip = soundName;
        sfx2DSource.Play();
    }
    
    // Sound to destroy
    public AudioClip destroySound;


}
