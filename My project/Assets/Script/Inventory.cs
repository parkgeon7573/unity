using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField]
    GameObject m_itemSlotPrefab;
    [SerializeField]
    GameObject m_itemPrefab;
    [SerializeField]
    UIGrid m_slotGrid;
    [SerializeField]
    UISprite m_cursorSprite;
    [SerializeField]
    UILabel m_slotInfoLabel;
    [SerializeField]
    Sprite[] m_icons;
    [SerializeField]
    TweenScale m_tweenScale;
    [SerializeField]
    ItemData[] m_itemDatas;
    Dictionary<ItemType, ItemData> m_itemDataTable = new Dictionary<ItemType, ItemData>();
    List<ItemSlot> m_itemSlotList = new List<ItemSlot>();
    int m_maxSlotCont = 24;
    int m_SlotcolumeCount = 6;
    int m_curSlotIndex = -1;
    public void ShowUI()
    {
        gameObject.SetActive(true);
        m_slotGrid.gameObject.SetActive(false);
        m_tweenScale.ResetToBeginning(); 
        m_tweenScale.PlayForward();
    }
    public void HideUI()
    {
        gameObject.SetActive(false);
    }
    public void OnSlotExpand()
    {
        CreateItemSlot(m_SlotcolumeCount);
        m_maxSlotCont += m_SlotcolumeCount;
    }
    public void OnUseItem()
    {
        if (m_curSlotIndex == -1) return;
        m_itemSlotList[m_curSlotIndex].OnUseItem();
        SetSlotInfo();
    }
    public void OnSelectSlot(ItemSlot slot)
    {
        /*for(int i = 0; i < m_itemSlotList.Count; i++)
        {
            if(m_itemSlotList[i].IsSelect)
            {
                m_itemSlotList[i].IsSelect = false;
                break;
            }
        }*/
        var result = m_itemSlotList.Find(element => element.IsSelect);
        if (result != null)
            result.IsSelect = false;
        slot.IsSelect = true;
        if (!m_cursorSprite.enabled) m_cursorSprite.enabled = true;
        m_cursorSprite.transform.position = slot.transform.position;
        m_curSlotIndex = int.Parse(slot.name.Split('_')[1]);
        
    }
    public void CreateItem()
    {
        for (int i = 0; i < m_itemSlotList.Count; i++)
        {
            if (m_itemSlotList[i].IsEmpty) 
            {
                int count = 0;
                var type = (ItemType)Random.Range((int)ItemType.Ball, (int)ItemType.Max);
                var itemData = m_itemDataTable[type];
                if (Random.Range(1, 101) <= 30)
                    count = 1;
                else
                    count = Random.Range(1, 100);
                ItemDataInfo itemDatainfo = new ItemDataInfo() { m_itemData = itemData, m_count = count };
                var obj = Instantiate(m_itemPrefab);
                var item = obj.GetComponent<Item>(); 
                item.SetItem(itemDatainfo, m_icons[itemData.m_icon]);
                m_itemSlotList[i].SetSlot(item);
                SetSlotInfo();
                break;
            }
        }
    }
    void SetSlotInfo()
    {
        int slotUsed = 0;
        var results = m_itemSlotList.FindAll(slot => !slot.IsEmpty);
        if (results != null)
            slotUsed = results.Count;
        m_slotInfoLabel.text = string.Format("{0}/{1}",slotUsed, m_itemSlotList.Count);
    }
    void CreateItemSlot(int count)
    {
        int curSlotCount = m_itemSlotList.Count;
        for(int i = 0; i < count; i++)
        {
            var obj = Instantiate(m_itemSlotPrefab);
            obj.transform.SetParent(m_slotGrid.transform);
            obj.transform.localScale = Vector3.one;
            var slot = obj.GetComponent<ItemSlot>();
            slot.InintSlot(this);
            slot.name = "slot_" + (curSlotCount + i);
            m_itemSlotList.Add(slot);
        }
        SetSlotInfo();
        m_slotGrid.repositionNow = true;
    } 
    void InitItemDataTable()
    {
        for (int i = 0; i < m_itemDatas.Length; i++)
        {
            m_itemDataTable.Add(m_itemDatas[i].m_type, m_itemDatas[i]);
        }
            
    }
    // Start is called before the first frame update
    void Start()
    {
        CreateItemSlot(m_maxSlotCont);
        
        InitItemDataTable();
        m_cursorSprite.enabled = false;
        HideUI();
    }
}
