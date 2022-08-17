using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlot : MonoBehaviour
{
    Item m_item;
    [SerializeField]
    Inventory m_inven;
    bool m_isSelect;
    
    public bool IsEmpty { get { return m_item == null; } }
    public bool IsSelect { get { return m_isSelect; } set { m_isSelect = value; } }
    public void InintSlot(Inventory inven)
    {
        m_inven = inven;
    }
    public void OnSelect()
    {
        m_inven.OnSelectSlot(this);
    }
    public void OnUseItem()
    {
        if (m_item == null) return;
        var count = m_item.DecreaseItem();
        if (count <= 0) m_item = null;
    }
    public void SetSlot(Item item)
    {
        m_item = item;
        item.transform.SetParent(transform);
        item.transform.localPosition = Vector3.zero;
        item.transform.localScale = Vector3.one; 
    }
    // Start is called before the first frame update
    void Start()
    {
        //m_inven = GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
    }
}
