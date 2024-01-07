using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : Inventory
{
    public void CancelTransaction()
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if(itemSlot.item.data != null)
            {
                itemSlot.item.owner.GetComponent<Inventory>().AddItem(itemSlot.item);
            }
        }

        Clear();
    }

    public void Clear()
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            RemoveItem(itemSlot);
        }
    }
}
