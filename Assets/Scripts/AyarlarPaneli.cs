// SoundManager.cs

using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;

    public Slider volumeSlider; // Ana menüdeki slider

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // SoundManager'ı diğer sahnelerde yok etme
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Slider'ın değerini kontrol etmek için bir event ekleyin
        volumeSlider.onValueChanged.AddListener(delegate { OnVolumeChange(); });

        // Başlangıçta ses seviyesini kontrol edin (örneğin, PlayerPrefs'ten okuyabilirsiniz)
        float savedVolume = PlayerPrefs.GetFloat("Volume", 1f);
        volumeSlider.value = savedVolume;
        AudioListener.volume = savedVolume;

        // Tüm sahnelerdeki sesleri kontrol etmek için sceneLoaded event'ini dinleyin
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnVolumeChange()
    {
        // Slider'ın değeri değiştiğinde çağrılır
        float volume = volumeSlider.value;

        // Ses seviyesini ayarla
        AudioListener.volume = volume;

        // Ses seviyesini PlayerPrefs veya başka bir kaydedilebilir mekanizma ile kaydedin
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.Save();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        // Yeni sahne yüklendiğinde sesleri kontrol et
        // Bu örnekte, sadece müzik sesi kontrol ediliyor, diğer sesleri de buraya ekleyebilirsiniz
        if (scene.name == "YourMusicSceneName")
        {
            // Örneğin, sahnede çalan müziği kontrol etme işlemleri buraya eklenir
            // Örneğin, AudioSource kullanarak müziği çalma, duraklatma, ses seviyesini ayarlama, vb.
        }
    }
}
