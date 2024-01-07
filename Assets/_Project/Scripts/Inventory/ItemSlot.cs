using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public ItemSO itemSO;
    public ItemSO.Type type;
    [HideInInspector] public Inventory inventory;

    public bool CanReceiveItem(ItemSO itemToReceive)
    {
        return type == ItemSO.Type.None || itemToReceive?.type == type || itemToReceive == null;
    }
}
