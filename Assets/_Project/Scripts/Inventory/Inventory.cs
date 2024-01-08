using System;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public Actor owner;

    [SerializeField] protected List<ItemSlot> itemSlots;
    public Action OnItemsChanged;

    private void Awake()
    {
        SetSlotsInventory();
    }

    public virtual void AddItem(Item item)
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item.data == null && itemSlot.CanReceiveItem(item))
            {
                itemSlot.item = item;
                break;
            }
        }

        OnItemsChanged?.Invoke();
    }

    public virtual void RemoveItem(ItemSlot itemSlot)
    {
        itemSlots[itemSlots.IndexOf(itemSlot)].item = new Item();
        OnItemsChanged?.Invoke();
    }

    public bool TrySwapItems(ItemSlot firstSlot, ItemSlot secondSlot)
    {
        if (!firstSlot.CanReceiveItem(secondSlot.item) || !secondSlot.CanReceiveItem(firstSlot.item))
            return false;

        Item temp = firstSlot.item;
        firstSlot.item = secondSlot.item;
        secondSlot.item = temp;
        firstSlot.inventory.OnItemsChanged?.Invoke();
        secondSlot.inventory.OnItemsChanged?.Invoke();
        return true;
    }

    public List<ItemSlot> GetItemSlots()
    {
        return itemSlots;
    }

    public int GetNonEmptySlotsCount()
    {
        int count = 0;

        foreach (ItemSlot itemSlot in itemSlots)
        {
            if(itemSlot.item.data != null)
                count++;
        }

        return count;
    }

    protected void SetSlotsInventory()
    {
        foreach (var slot in itemSlots)
        {
            slot.inventory = this;
            if(owner != null)
                slot.item.owner = owner;
        }
    }
}
