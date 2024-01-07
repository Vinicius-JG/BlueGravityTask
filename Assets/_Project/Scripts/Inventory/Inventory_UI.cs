using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    public Inventory inventory;
    public Transform itemsHolder;

    private void Awake()
    {
        RefreshItems();
        inventory.OnItemsChanged += RefreshItems;
    }

    void RefreshItems()
    {
        for (int i = 0; i < itemsHolder.childCount; i++)
        {
            if (i < inventory.GetItems().Count)
                itemsHolder.GetChild(i).GetComponent<ItemSlot_UI>()?.Initialize(inventory.GetItems()[i], inventory);
            else
                itemsHolder.GetChild(i).GetComponent<ItemSlot_UI>()?.Initialize(null, inventory);
        }
    }
}
