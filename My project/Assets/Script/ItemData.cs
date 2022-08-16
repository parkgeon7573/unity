using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Ball,
    Bomb,
    BowlingBall,
    Coin,
    Hat,
    Magnet,
    Max
}
[System.Serializable]
public struct ItemData
{
    public ItemType m_type;
    public int m_icon;
}
public struct ItemDataInfo
{
    public ItemData m_itemData;
    public int m_count;
}
