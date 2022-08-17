using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    UI2DSprite m_iconSprite;
    [SerializeField]
    UILabel m_countLable;
    ItemDataInfo m_itemDataInfo;
    public void SetItem(ItemDataInfo itemDataInfo, Sprite icon)
    {
        m_iconSprite.sprite2D = icon;
        m_itemDataInfo = itemDataInfo;
        ResetCount(); 
    }
    public int DecreaseItem()
    {
        m_itemDataInfo.m_count--;
        ResetCount();
        if (m_itemDataInfo.m_count <= 0)
        {
            Destroy(gameObject);
        }
        return m_itemDataInfo.m_count;
    }
    private void ResetCount()
    {
        if (m_itemDataInfo.m_count == 1)
        {
            m_countLable.transform.parent.gameObject.SetActive(false);
        }
        else
        {
            m_countLable.text = m_itemDataInfo.m_count.ToString();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }
}
