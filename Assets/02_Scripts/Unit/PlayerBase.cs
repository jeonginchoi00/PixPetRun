using UnityEngine;
using Globals;

public class PlayerBase : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    private float m_speed = 2f;
    private bool m_isGround = true;

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        Move();
        Jump();
    }

    public virtual void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.transform.CompareTag(Tag.GROUND))
        {
            m_isGround = true;
            m_animator.SetTrigger(AnimKey.GROUND);
        }
    }

    #region override
    public virtual void Move()
    {
        if (Input.GetButton(InputType.HORIZONTAL))
        {
            float h = Input.GetAxisRaw(InputType.HORIZONTAL);
            Vector2 movement = new Vector2(h, 0);
            transform.Translate(movement.normalized * m_speed * Time.deltaTime);

            if (h > 0)
                transform.localScale = new Vector2(1, 1);
            if (h < 0)
                transform.localScale = new Vector2(-1, 1);

            m_animator.SetFloat(AnimKey.SPEED, 1);
        }
        else
        {
            m_animator.SetFloat(AnimKey.SPEED, 0);
        }
    }

    public virtual void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && m_isGround)
        {
            m_rigidbody.AddForce(Vector2.up * 300);
            m_animator.SetTrigger(AnimKey.JUMP);
            m_isGround = false;
        }
    }
    #endregion
}
