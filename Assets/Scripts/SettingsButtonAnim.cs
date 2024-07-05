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

        // Animasyonu baþlatmak için trigger'ý tetikle
        animator.SetTrigger("settingsanim");

        // Animasyon tamamlandýktan sonra Animator bileþenini devre dýþý býrak
        Invoke("DisableAnimator", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void DisableAnimator()
    {
        animator.enabled = false;
    }

}
