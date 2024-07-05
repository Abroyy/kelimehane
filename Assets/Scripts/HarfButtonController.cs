using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarfButtonController : MonoBehaviour
{
    public List<Button> harfButtons; // Harf butonlar�n� tutacak liste
    public InputField harfInputField; // Harf input field'�
    public Cogalacak cogalacakScript; // Cogalacak script'e eri�im
    public AudioSource click;

    public List<string> harfListesi; // Harfleri i�eren liste

    private string selectedHarfler = ""; // T�klanan harfleri saklayan string

    void Start()
    {
        click = GetComponent<AudioSource>();
        click.Stop();
        AssignHarfButtons();
    }

    
    void AssignHarfButtons()
    {
        for (int i = 0; i < harfButtons.Count; i++)
        {
            string harf = harfListesi[i]; // Butonun harfini belirleme

            harfButtons[i].onClick.AddListener(() => OnHarfButtonClick(harf));
        }
    }

    void OnHarfButtonClick(string harf)
    {
        click.Play();
        selectedHarfler += harf; // T�klanan harfi saklama
        harfInputField.text = selectedHarfler; // Harfleri Input Field'a yazma
    }

    public void OnSilmeButtonClick()
    {
        click.Play();
        if (selectedHarfler.Length > 0)
        {
            selectedHarfler = selectedHarfler.Substring(0, selectedHarfler.Length - 1); // Son harfi silme
            harfInputField.text = selectedHarfler; // G�ncellenmi� harfleri Input Field'a yazma
        }
    }

    public void YaziyiSil()
    {
        selectedHarfler = "";
    }
}
