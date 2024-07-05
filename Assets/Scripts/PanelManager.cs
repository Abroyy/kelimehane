using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels; // Panel dizisi
    public Button[] levelButtons; // Level butonlarý dizisi

    private int currentPanelIndex = 0;
    public int nextLevelIndex;
    public int currentLevelIndex; // Eklenen satýr

    void Start()
    {
        // Set the current level index
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        // En son tamamlanan panelin bilgisini yükle
        if (PlayerPrefs.HasKey("LastCompletedPanel_" + currentLevelIndex))
        {
            currentPanelIndex = PlayerPrefs.GetInt("LastCompletedPanel_" + currentLevelIndex);
        }

        // Panelleri ve butonlarý güncelle
        UpdatePanelsAndButtons();
    }

    // Panel tamamlandýðýnda çaðrýlan fonksiyon
    public void CompletePanel()
    {
        // Mevcut paneli tamamlanmýþ olarak iþaretle
        PlayerPrefs.SetInt("LevelButton_" + currentLevelIndex + "_" + currentPanelIndex, 1);

        // Mevcut paneli kapat
        panels[currentPanelIndex].SetActive(false);

        // Bir sonraki paneli aktif et
        currentPanelIndex++;

        // Eðer son panelse, bir þey yapma
        if (currentPanelIndex >= panels.Length)
        {
            Debug.Log("Oyun bitti!");

            // PlayerPrefs'ten bir sonraki seviyenin kilidini aç
            int nextLevel = currentLevelIndex + 1;

            // Eðer nextLevelIndex belirlenmiþse, onu kullan
            if (nextLevelIndex > 0)
            {
                nextLevel = nextLevelIndex;
            }

            PlayerPrefs.SetInt("Level" + nextLevel.ToString(), 1);

            SceneManager.LoadScene("Levels");
            return;
        }

        // Bir sonraki paneli aktif et
        panels[currentPanelIndex].SetActive(true);

        // Bir sonraki panelin butonunu aktif et
        levelButtons[currentPanelIndex].interactable = true;

        // Bir sonraki butonun aktifliðini kaydet
        PlayerPrefs.SetInt("LevelButton_" + currentLevelIndex + "_" + currentPanelIndex, 1);

        // En son tamamlanan panelin bilgisini güncelle
        PlayerPrefs.SetInt("LastCompletedPanel_" + currentLevelIndex, currentPanelIndex);

        // Diðer panelleri devre dýþý býrak
        for (int i = 0; i < currentPanelIndex; i++)
        {
            panels[i].SetActive(false);
            levelButtons[i].interactable = true;
        }
    }

    // Panelleri ve butonlarý güncelleyen yardýmcý fonksiyon
    void UpdatePanelsAndButtons()
    {
        // Ýlk panel dýþýndaki tüm panelleri devre dýþý býrak
        for (int i = 1; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        // Buton aktiflik durumlarýný yükle
        for (int i = 1; i < levelButtons.Length; i++)
        {
            // Eðer PlayerPrefs'te bir kayýt varsa, o deðeri kullan
            if (PlayerPrefs.HasKey("LevelButton_" + currentLevelIndex + "_" + i))
            {
                int buttonState = PlayerPrefs.GetInt("LevelButton_" + currentLevelIndex + "_" + i);
                levelButtons[i].interactable = buttonState == 1;
            }
            else
            {
                // Varsayýlan olarak butonlarý devre dýþý býrak
                levelButtons[i].interactable = false;
            }
        }
    }
}
