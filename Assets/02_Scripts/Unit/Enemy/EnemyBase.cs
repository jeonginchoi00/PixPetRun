using UnityEngine;
using Globals;

public class EnemyBase : MonoBehaviour
{
    private Animator m_animator;
    private int m_hitCount;
    private int m_maxHit = 2;

    public virtual void Start()
    {
        m_animator = GetComponent<Animator>();

        Move();
    }

    #region override
    public virtual void SetHitCount()
    {
        m_hitCount++;
        m_animator.SetTrigger(AnimKey.HIT);

        if (m_hitCount >= m_maxHit)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        Destroy(gameObject, 0.5f);
    }

    public virtual void Move()
    {

    }
    #endregion
}
