using UnityEngine;
using UnityEngine.SceneManagement;

public class S_GameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        S_MusicManager.Instance.PlayMusic("Credits");
    }
    
    // Méthode pour relancer le jeu
    public void Replay()
    {
        // Redirige vers la scène principale du jeu
        SceneManager.LoadScene("EstebanScene02");
    }

}
