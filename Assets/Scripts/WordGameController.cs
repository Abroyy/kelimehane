using UnityEngine;
using UnityEngine.UI;

public class WordGameController : MonoBehaviour
{
    public Text wordText;
    public InputField answerInput;

    private string[] words = { "kedi", "köpek", "masa", "kitap", "bilgisayar" };
    private string currentWord;

    void Start()
    {
        // Oyun başladığında ilk kelimeyi göster
        ShowRandomWord();
    }

    void ShowRandomWord()
    {
        // Rastgele bir kelime seç
        currentWord = words[Random.Range(0, words.Length)];

        // Seçilen kelimeyi ekrana yazdır
        wordText.text = currentWord;
    }

    public void CheckAnswer()
    {
        // Kullanıcının girdiği cevabı kontrol et
        string userAnswer = answerInput.text.ToLower();

        // Doğru cevap kontrolü
        if (userAnswer == currentWord)
        {
            Debug.Log("Doğru Cevap!");
            // Bir sonraki kelimeyi göster
            ShowRandomWord();

            // Cevap input'unu temizle
            answerInput.text = "";
        }
        else
        {
            Debug.Log("Yanlış Cevap. Tekrar Deneyin.");
        }
    }
}
