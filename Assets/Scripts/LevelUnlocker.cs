using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelUnlocker : MonoBehaviour
{
    public Button[] levelButtons;  // Unity Editor �zerinde butonlar� atayabilece�in bir dizi

    void Start()
    {
        // PlayerPrefs'ten seviye durumlar�n� kontrol et
        for (int i = 0; i < levelButtons.Length; i++)
        {
            int levelIndex = i + 1;  // Seviye indeksi 0'dan ba�lamad��� i�in +1 ekliyoruz
            bool isUnlocked = PlayerPrefs.GetInt("Level" + levelIndex.ToString(), i == 0 ? 1 : 0) == 1;

            // Seviye kilitliyse butonu kitle, de�ilse a��k b�rak
            levelButtons[i].interactable = isUnlocked;
        }
    }

    // Her seviye butonuna t�kland���nda �a�r�lacak metod
    public void LoadLevel(int levelIndex)
    {
        // Seviye kilidi a��k m� kontrol et
        if (PlayerPrefs.GetInt("Level" + levelIndex.ToString(), 0) == 1)
        {
            SceneManager.LoadScene("Level" + levelIndex.ToString());
        }
        else
        {
            // Seviye kilitli, uygun bir mesaj g�sterilebilir
            Debug.Log("Bu seviye kilitli. �nceki seviyeleri tamamlayarak kilidi a��n.");
        }
    }
}
