using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HarfButtonController : MonoBehaviour
{
    public List<Button> harfButtons; // Harf butonlarýný tutacak liste
    public InputField harfInputField; // Harf input field'ý
    public Cogalacak cogalacakScript; // Cogalacak script'e eriþim
    public AudioSource click;

    public List<string> harfListesi; // Harfleri içeren liste

    private string selectedHarfler = ""; // Týklanan harfleri saklayan string

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
        selectedHarfler += harf; // Týklanan harfi saklama
        harfInputField.text = selectedHarfler; // Harfleri Input Field'a yazma
    }

    public void OnSilmeButtonClick()
    {
        click.Play();
        if (selectedHarfler.Length > 0)
        {
            selectedHarfler = selectedHarfler.Substring(0, selectedHarfler.Length - 1); // Son harfi silme
            harfInputField.text = selectedHarfler; // Güncellenmiþ harfleri Input Field'a yazma
        }
    }

    public void YaziyiSil()
    {
        selectedHarfler = "";
    }
}
