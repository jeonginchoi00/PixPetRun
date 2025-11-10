using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager m_instance;
    public static GameManager GetInstance() => m_instance;

    private List<Item> m_itemList = new List<Item>();
    public int ItemCount => m_itemList.Count;

    private void Awake()
    {
        if (m_instance == null)
        {
            m_instance = this;
        }
    }

    private void OnDestroy()
    {
        if (m_instance == this)
        {
            m_instance = null;
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
