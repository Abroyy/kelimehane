using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneSec : MonoBehaviour
{
    public string sceneName; // Sahnenin ad�n� tutmak i�in

    public void LoadSceneWithDelay()
    {
        // Invoke ile LoadScene metodunu 1 saniye gecikme ile �a��r
        Invoke("LoadScene", 1f);
    }

    private void LoadScene()
    {
        // Sahneyi y�kle
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
