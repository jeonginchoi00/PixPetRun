using System.Collections.Generic;
using UnityEngine;
using Globals;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager GetInstance() => m_instance;

    private List<Item> m_itemList = new List<Item>();
    private float m_timer = 0f;

    public int ItemCount => m_itemList.Count;
    public float Score => m_timer;
    public GameState CurrentState { get; private set; } = GameState.GAME_START;


    private void Awake()
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

    private void Start()
    {
        SetGameState(GameState.GAME_START);
    }

    private void Update()
    {
        if (CurrentState != GameState.GAME_END)
        {
            m_timer += Time.deltaTime;
        }
    }

    public void SetGameState(GameState _state)
    {
        CurrentState = _state;

        switch (_state)
        {
            case GameState.GAME_START:
                m_itemList.Clear();
                break;
            case GameState.GAME_CLEAR:
                LoadSceneManager.GetInstance().LoadNextStage();
                break;
            case GameState.GAME_END:
                LoadSceneManager.GetInstance().ReLoadScene();
                break;
        }
    }

    #region Item
    public void RegisterItem(Item _item)
    {
        if (!m_itemList.Contains(_item))
        {
            m_itemList.Add(_item);
        }
    }

    public void UnRegisterItem(Item _item)
    {
        if (m_itemList.Contains(_item))
        {
            m_itemList.Remove(_item);
        }
    }
    #endregion
}
