using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] protected List<ItemSlot> itemSlots;
    public Action OnItemsChanged;

    private void Awake()
    {
        SetSlotsInventory();
    }

    public virtual void AddItem(ItemSO item, int position)
    {
        if (!itemSlots[position].CanReceiveItem(item))
            return;

        itemSlots[position].itemSO = item;
        OnItemsChanged?.Invoke();
    }

    public bool TrySwapItems(ItemSlot firstSlot, ItemSlot secondSlot)
    {
        if (!firstSlot.CanReceiveItem(secondSlot.itemSO) || !secondSlot.CanReceiveItem(firstSlot.itemSO))
            return false;

        ItemSO temp = firstSlot.itemSO;
        firstSlot.itemSO = secondSlot.itemSO;
        secondSlot.itemSO = temp;
        firstSlot.inventory.OnItemsChanged?.Invoke();
        secondSlot.inventory.OnItemsChanged?.Invoke();
        return true;
    }

    public List<ItemSlot> GetItemSlots()
    {
        return itemSlots;
    }

    protected void SetSlotsInventory()
    {
        foreach (var slot in itemSlots)
        {
            slot.inventory = this;
        }
    }
}
