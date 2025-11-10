using UnityEngine;

public class StartManager : MonoBehaviour
{
    private static StartManager m_instance;
    public static StartManager GetInstance() => m_instance;

    private void Start()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }

        StartUIManager.GetInstance().Initialize();
    }

    private void OnDestroy()
    {
        if (m_instance == this)
        {
            m_instance = null;
        }
    }
}
