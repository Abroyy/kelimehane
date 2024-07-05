using UnityEngine;
using UnityEngine.UI;

public class DualSliderController : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;

    private void Start()
    {
        // Slider1'in deðerini kontrol etmek için bir event ekleyin
        slider1.onValueChanged.AddListener(delegate { OnSlider1Change(); });

        // Baþlangýçta Slider2'yi Slider1 ile senkronize et
        SyncSliders();
    }

    private void OnSlider1Change()
    {
        // Slider1'in deðeri deðiþtiðinde çaðrýlýr
        SyncSliders();
    }

    private void SyncSliders()
    {
        // Slider2'nin deðerini Slider1'in deðerine eþitle
        slider2.value = slider1.value;
    }
}
