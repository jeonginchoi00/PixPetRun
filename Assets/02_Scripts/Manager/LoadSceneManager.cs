using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : MonoBehaviour
{
    private static LoadSceneManager m_instance;
    public static LoadSceneManager GetInstance() => m_instance;

    private void Start()
    {
        if (m_instance == null)
        {
            m_instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadScene(string _scene)
    {
        if (string.IsNullOrEmpty(_scene))
        {
            return;
        }

        SceneManager.LoadScene(_scene);
    }

    public void LoadNextStage()
    {
        string currentScene = SceneManager.GetActiveScene().name;
        string currentStage = currentScene.Substring(currentScene.Length - 2);
        int nextStage = int.Parse(currentStage) + 1;
        string nextScene = $"Stage_{nextStage:D2}";

        SceneManager.LoadScene(nextScene);
    }
}
