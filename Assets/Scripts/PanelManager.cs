using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelManager : MonoBehaviour
{
    public GameObject[] panels; // Panel dizisi
    public Button[] levelButtons; // Level butonlar� dizisi

    private int currentPanelIndex = 0;
    public int nextLevelIndex;
    public int currentLevelIndex; // Eklenen sat�r

    void Start()
    {
        // Set the current level index
        currentLevelIndex = SceneManager.GetActiveScene().buildIndex;

        // En son tamamlanan panelin bilgisini y�kle
        if (PlayerPrefs.HasKey("LastCompletedPanel_" + currentLevelIndex))
        {
            currentPanelIndex = PlayerPrefs.GetInt("LastCompletedPanel_" + currentLevelIndex);
        }

        // Panelleri ve butonlar� g�ncelle
        UpdatePanelsAndButtons();
    }

    // Panel tamamland���nda �a�r�lan fonksiyon
    public void CompletePanel()
    {
        // Mevcut paneli tamamlanm�� olarak i�aretle
        PlayerPrefs.SetInt("LevelButton_" + currentLevelIndex + "_" + currentPanelIndex, 1);

        // Mevcut paneli kapat
        panels[currentPanelIndex].SetActive(false);

        // Bir sonraki paneli aktif et
        currentPanelIndex++;

        // E�er son panelse, bir �ey yapma
        if (currentPanelIndex >= panels.Length)
        {
            Debug.Log("Oyun bitti!");

            // PlayerPrefs'ten bir sonraki seviyenin kilidini a�
            int nextLevel = currentLevelIndex + 1;

            // E�er nextLevelIndex belirlenmi�se, onu kullan
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

        // Bir sonraki butonun aktifli�ini kaydet
        PlayerPrefs.SetInt("LevelButton_" + currentLevelIndex + "_" + currentPanelIndex, 1);

        // En son tamamlanan panelin bilgisini g�ncelle
        PlayerPrefs.SetInt("LastCompletedPanel_" + currentLevelIndex, currentPanelIndex);

        // Di�er panelleri devre d��� b�rak
        for (int i = 0; i < currentPanelIndex; i++)
        {
            panels[i].SetActive(false);
            levelButtons[i].interactable = true;
        }
    }

    // Panelleri ve butonlar� g�ncelleyen yard�mc� fonksiyon
    void UpdatePanelsAndButtons()
    {
        // �lk panel d���ndaki t�m panelleri devre d��� b�rak
        for (int i = 1; i < panels.Length; i++)
        {
            panels[i].SetActive(false);
        }

        // Buton aktiflik durumlar�n� y�kle
        for (int i = 1; i < levelButtons.Length; i++)
        {
            // E�er PlayerPrefs'te bir kay�t varsa, o de�eri kullan
            if (PlayerPrefs.HasKey("LevelButton_" + currentLevelIndex + "_" + i))
            {
                int buttonState = PlayerPrefs.GetInt("LevelButton_" + currentLevelIndex + "_" + i);
                levelButtons[i].interactable = buttonState == 1;
            }
            else
            {
                // Varsay�lan olarak butonlar� devre d��� b�rak
                levelButtons[i].interactable = false;
            }
        }
    }
}
