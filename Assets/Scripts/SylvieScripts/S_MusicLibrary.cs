using UnityEngine;

[System.Serializable]
public struct MusicTrack
{
    public string trackName;
    public AudioClip clip;
}

public class S_MusicLibrary : MonoBehaviour
{
    public MusicTrack[] musicTracks;

    public AudioClip GetClipFromName(string trackName)
    {
        foreach (MusicTrack track in musicTracks)
        {
            if (track.trackName == trackName)
            {
                return track.clip;
            }
        }
        Debug.LogWarning("Musique non trouvé : " + trackName);
        return null;
    }
}
