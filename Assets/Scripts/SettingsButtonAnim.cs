using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsButtonAnim : MonoBehaviour
{

    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        // Animasyonu ba�latmak i�in trigger'� tetikle
        animator.SetTrigger("settingsanim");

        // Animasyon tamamland�ktan sonra Animator bile�enini devre d��� b�rak
        Invoke("DisableAnimator", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void DisableAnimator()
    {
        animator.enabled = false;
    }

}
