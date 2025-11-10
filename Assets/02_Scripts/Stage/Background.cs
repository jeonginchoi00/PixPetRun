using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] private MeshRenderer m_meshRenderer;
    private float m_speed = 1f;

    private void Update()
    {
        Vector2 newOffset = m_meshRenderer.material.mainTextureOffset;
        newOffset.y += m_speed * Time.deltaTime;

        m_meshRenderer.material.mainTextureOffset = newOffset;
    }
}
