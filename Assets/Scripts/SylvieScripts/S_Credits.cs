using UnityEngine;

public class S_Credits : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
         S_MusicManager.Instance.PlayMusic("MainMenu");
    }

}
