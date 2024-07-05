using UnityEngine;
using UnityEngine.UI;

public class DualSliderController : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;

    private void Start()
    {
        // Slider1'in de�erini kontrol etmek i�in bir event ekleyin
        slider1.onValueChanged.AddListener(delegate { OnSlider1Change(); });

        // Ba�lang��ta Slider2'yi Slider1 ile senkronize et
        SyncSliders();
    }

    private void OnSlider1Change()
    {
        // Slider1'in de�eri de�i�ti�inde �a�r�l�r
        SyncSliders();
    }

    private void SyncSliders()
    {
        // Slider2'nin de�erini Slider1'in de�erine e�itle
        slider2.value = slider1.value;
    }
}
