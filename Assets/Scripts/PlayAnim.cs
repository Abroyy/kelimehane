using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Animator bile�enini al
        animator = GetComponent<Animator>();

        // Animasyonu ba�latmak i�in trigger'� tetikle
        animator.SetTrigger("playanim");

        // Animasyon tamamland�ktan sonra Animator bile�enini devre d��� b�rak
        Invoke("DisableAnimator", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void DisableAnimator()
    {
        animator.enabled = false;
    }
}
