using UnityEngine;
using UnityEngine.SceneManagement;

public class S_PauseMenu : MonoBehaviour
{
    public GameObject container;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            container.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void ResumeButton()
    {
            container.SetActive(false);
            Time.timeScale = 1;
    }
    
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
