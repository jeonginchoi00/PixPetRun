using UnityEngine;

public class EndManager : MonoBehaviour
{
    private static EndManager m_instance;
    public static EndManager GetInstance() => m_instance;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }

        EndUIManager.GetInstance().Initialize();
    }

    private void OnDestroy()
    {
        if (m_instance == this)
        {
            m_instance = null;
        }
    }
}
