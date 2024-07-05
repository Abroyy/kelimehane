using UnityEngine;

public class PanelController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Animator bileþenini alýn
        animator = GetComponent<Animator>();
    }

    // Paneli açan fonksiyon
    public void OpenPanel()
    {
        // "settingspanelopen" adlý tetikleyiciyi baþlat
        animator.SetTrigger("settingspanelopen");
        
    }

    // Paneli kapatan fonksiyon
    public void ClosePanel()
    {
        // "settingspanelclose" adlý tetikleyiciyi baþlat
        animator.SetTrigger("settingspanelclose");
    }
}
