using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public Button[] levelButtons;
    public GameObject[] levelPanels;
    public GameObject[] otherButtons;
    public GameObject[] otherImages;

    void Start()
    {
        // T�m panelleri ve di�er nesneleri ba�lang��ta devre d��� b�rak
        
    }

    public void OnLevelButtonClicked(int levelIndex)
    {
        // T�m panelleri ve di�er nesneleri devre d��� b�rak
        DeactivateAllPanels();
        DeactivateOtherObjects();

        // Belirli seviyenin panelini etkinle�tir
        levelPanels[levelIndex].SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        DeactivateAllPanels();
        ActivateOtherObjects();
    }


    void DeactivateAllPanels()
    {
        // T�m panelleri devre d��� b�rak
        foreach (var panel in levelPanels)
        {
            panel.SetActive(false);
        }
    }

    void DeactivateOtherObjects()
    {
        // Di�er butonlar� ve g�rselleri devre d��� b�rak
        foreach (var button in otherButtons)
        {
            button.SetActive(false);
        }

        foreach (var image in otherImages)
        {
            image.SetActive(false);
        }
    }

    void ActivateOtherObjects()
    {
        // Di�er butonlar� ve g�rselleri etkinle�tir
        foreach (var button in otherButtons)
        {
            button.SetActive(true);
        }

        foreach (var image in otherImages)
        {
            image.SetActive(true);
        }
    }

    public void LevelsMenu()
    {
        SceneManager.LoadScene("Levels");
    }


}
