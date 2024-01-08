using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : Inventory
{
    Actor customer;
    Inventory shopInventory;
    int total;

    private void Awake()
    {
        SetSlotsInventory();
        OnItemsChanged += CalculateTotal;
    }

    public void SetBasket(Actor customer, Inventory shopInventory)
    {
        this.customer = customer;
        this.shopInventory = shopInventory;
    }

    public void ConfirmTransaction()
    {
        if (!IsAValidTransaction() || GetNonEmptySlotsCount() == 0)
            return;

        customer.ChangeMoney(GetTotal());

        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item.data != null)
            {
                if (itemSlot.item.owner == customer)
                {
                    itemSlot.item.owner = shopInventory.owner;
                    shopInventory.AddItem(itemSlot.item);
                }
                else if (itemSlot.item.owner == shopInventory.owner)
                {
                    itemSlot.item.owner = customer;
                    customer.GetComponent<Inventory>().AddItem(itemSlot.item);
                }
            }
        }

        Clear();
        AudioManager.Instance.PlaySFX(AudioManager.Instance.genericAudioClips[2]);
    }

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

    void CalculateTotal()
    {
        total = 0;

        foreach (ItemSlot itemSlot in itemSlots)
        {
            if (itemSlot.item.data != null)
            {
                if(itemSlot.item.owner == customer)
                    total += itemSlot.item.data.price;
                else
                    total -= itemSlot.item.data.price;
            }
        }
    }

    public bool IsAValidTransaction()
    {
        return customer.GetMoney() >= -total;
    }

    public Actor GetCustomer()
    {
        return customer;
    }

    public Inventory GetShopInventory()
    {
        return shopInventory;
    }

    public int GetTotal()
    {
        return total;
    }
}
