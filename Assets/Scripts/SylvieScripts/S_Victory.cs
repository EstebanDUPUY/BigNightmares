using UnityEngine;

public class S_Victory : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        S_MusicManager.Instance.PlayMusic("Victory");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
