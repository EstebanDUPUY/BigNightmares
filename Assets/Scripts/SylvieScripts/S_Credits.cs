using UnityEngine;

public class S_Credits : MonoBehaviour
{
    public float scrollSpeed = 400f;

    public RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        S_MusicManager.Instance.PlayMusic("Credits");
        rectTransform = GetComponent<RectTransform>();
    }
    
    private void Update()
    {
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }

}
