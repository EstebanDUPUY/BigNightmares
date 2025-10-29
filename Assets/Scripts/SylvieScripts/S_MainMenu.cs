using UnityEngine;
using UnityEngine.SceneManagement;

public class S_MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Play()
    {
        SceneManager.LoadScene("Esteban01");
    }

    // Update is called once per frame
    public void Quit()
    {
        Application.Quit();
    }
}
