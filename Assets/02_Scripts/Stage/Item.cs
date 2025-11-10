using UnityEngine;
using Globals;

public class Item : MonoBehaviour
{
    [SerializeField] private GameObject m_collectedEffect;

    private void Start()
    {
        GameManager.GetInstance().RegisterItem(this);
    }

    private void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.transform.CompareTag(Tag.PLAYER))
        {
            GameManager.GetInstance().UnRegisterItem(this);
            GameObject effect = Instantiate(m_collectedEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            Destroy(gameObject);
        }
    }
}
