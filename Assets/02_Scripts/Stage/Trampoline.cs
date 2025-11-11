using UnityEngine;
using Globals;

public class Trampoline : MonoBehaviour
{
    private Animator m_animator;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.transform.CompareTag(Tag.PLAYER))
        {
            SoundManager.GetInstance().PlaySFX(SoundType.SFX_SPRING);
            m_animator.SetTrigger(AnimKey.TRAMJUMP);
        }
    }
}
