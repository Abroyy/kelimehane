using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsSystem : MonoBehaviour
{
    
    public GameObject settingspanel;
    public GameObject settingsbutton;
    Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        settingsbutton.SetActive(true);
        
    }

    public void SettingsPanel()
    {
        
        anim.SetTrigger("panel1anim");
        settingsbutton.SetActive(false);
    }

    public void SettingsPanelClose()
    {
       
        anim.SetTrigger("panel1cikis");
        settingsbutton.SetActive(true);
    }

    public void MainMenuye()
    {
        SceneManager.LoadScene("MainMenu");

    }

    public void DonMainMenu()
    {
       
        Invoke("MainMenuye", 0.8f);
        anim.SetTrigger("panel1cikis");
    }

    public void LevelsMenu()
    {
        SceneManager.LoadScene("Levels");
    }
}
