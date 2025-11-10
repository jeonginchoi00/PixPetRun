using UnityEngine;
using Globals;

public class PlayerBase : MonoBehaviour
{
    private Animator m_animator;
    private Rigidbody2D m_rigidbody;
    private float m_speed = 2f;
    private bool m_isGround = true;

    public float Speed { get => m_speed; set => m_speed = value; }

    private void Start()
    {
        m_animator = GetComponent<Animator>();
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    #region override
    public virtual void Update()
    {
        Move();
        Jump();
    }

    public virtual void OnCollisionEnter2D(Collision2D _collision)
    {
        if (_collision.transform.CompareTag(Tag.GROUND) || _collision.transform.CompareTag(Tag.POINT) || _collision.transform.CompareTag(Tag.ICEGROUND))
        {
            m_isGround = true;
            m_animator.SetTrigger(AnimKey.GROUND);
        }

        if (_collision.transform.CompareTag(Tag.POINT))
        {
            if (GameManager.GetInstance().ItemCount == 0)
            {
                GameManager.GetInstance().SetGameState(GameState.GAME_CLEAR);
            }
        }
    }

    public virtual void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.transform.CompareTag(Tag.ENEMY))
        {
            GameManager.GetInstance().SetGameState(GameState.GAME_END);
        }
    }

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
