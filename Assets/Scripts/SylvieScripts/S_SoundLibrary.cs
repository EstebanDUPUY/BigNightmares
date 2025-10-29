using UnityEngine;

[System.Serializable]
public struct SoundEffect
{
    public string groupID;
    public AudioClip[] clip;
}

public class S_SoundLibrary : MonoBehaviour
{
    public SoundEffect[] soundEffects;

    public AudioClip GetClipFromName(string name)
    {
        foreach (SoundEffect sfx in soundEffects)
        {
            if (sfx.groupID == name)
            {
                int randomIndex = Random.Range(0, sfx.clip.Length);
                return sfx.clip[randomIndex];
            }
        }
        Debug.LogWarning("Sound effect not found: " + name);
        return null;
    }
}
