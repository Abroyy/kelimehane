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
        // Tüm panelleri ve diðer nesneleri baþlangýçta devre dýþý býrak
        
    }

    public void OnLevelButtonClicked(int levelIndex)
    {
        // Tüm panelleri ve diðer nesneleri devre dýþý býrak
        DeactivateAllPanels();
        DeactivateOtherObjects();

        // Belirli seviyenin panelini etkinleþtir
        levelPanels[levelIndex].SetActive(true);
    }

    public void OnBackButtonClicked()
    {
        DeactivateAllPanels();
        ActivateOtherObjects();
    }


    void DeactivateAllPanels()
    {
        // Tüm panelleri devre dýþý býrak
        foreach (var panel in levelPanels)
        {
            panel.SetActive(false);
        }
    }

    void DeactivateOtherObjects()
    {
        // Diðer butonlarý ve görselleri devre dýþý býrak
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
        // Diðer butonlarý ve görselleri etkinleþtir
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
