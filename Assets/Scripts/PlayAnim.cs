using UnityEngine;

public class PlayAnim : MonoBehaviour
{
    private Animator animator;

    private void Start()
    {
        // Animator bileþenini al
        animator = GetComponent<Animator>();

        // Animasyonu baþlatmak için trigger'ý tetikle
        animator.SetTrigger("playanim");

        // Animasyon tamamlandýktan sonra Animator bileþenini devre dýþý býrak
        Invoke("DisableAnimator", animator.GetCurrentAnimatorStateInfo(0).length);
    }

    private void DisableAnimator()
    {
        animator.enabled = false;
    }
}
