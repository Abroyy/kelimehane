using UnityEngine;

public class PanelController : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Animator bile�enini al�n
        animator = GetComponent<Animator>();
    }

    // Paneli a�an fonksiyon
    public void OpenPanel()
    {
        // "settingspanelopen" adl� tetikleyiciyi ba�lat
        animator.SetTrigger("settingspanelopen");
        
    }

    // Paneli kapatan fonksiyon
    public void ClosePanel()
    {
        // "settingspanelclose" adl� tetikleyiciyi ba�lat
        animator.SetTrigger("settingspanelclose");
    }
}
