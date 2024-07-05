using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Button[] levelButtons;  // Unity Editor üzerinde butonlarý atayabileceðin bir dizi

    void Start()
    {
        // PlayerPrefs'ten seviye durumlarýný kontrol et
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;  // Seviye indeksi 0'dan baþlamadýðý için +1 ekliyoruz
            bool isUnlocked = PlayerPrefs.GetInt("Level" + levelIndex.ToString(), i == 0 ? 1 : 0) == 1;

            // Seviye kilitliyse butonu kitle, deðilse açýk býrak
            levelButtons[i].interactable = isUnlocked;
        }
    }

    // Her seviye butonuna týklandýðýnda çaðrýlacak metod
    public void LoadLevel(int levelIndex)
    {
        // Seviye kilidi açýk mý kontrol et
        if (PlayerPrefs.GetInt("Level" + levelIndex.ToString(), 0) == 1)
        {
            SceneManager.LoadScene("Level" + levelIndex.ToString());
        }
        else
        {
            // Seviye kilitli, uygun bir mesaj gösterilebilir
            Debug.Log("Bu seviye kilitli. Önceki seviyeleri tamamlayarak kilidi açýn.");
        }
    }
}
