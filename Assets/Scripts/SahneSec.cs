using UnityEngine;
using UnityEngine.SceneManagement;

public class SahneSec : MonoBehaviour
{
    public string sceneName; // Sahnenin adýný tutmak için

    public void LoadSceneWithDelay()
    {
        // Invoke ile LoadScene metodunu 1 saniye gecikme ile çaðýr
        Invoke("LoadScene", 1f);
    }

    private void LoadScene()
    {
        // Sahneyi yükle
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
