using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSlot
{
    public Item item;
    public ItemSO.Type type;
    [HideInInspector] public Inventory inventory;

    public bool CanReceiveItem(Item itemToReceive)
    {
        return type == ItemSO.Type.None || itemToReceive.data?.type == type || itemToReceive.data == null;
    }
}
