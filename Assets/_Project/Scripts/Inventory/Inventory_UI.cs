using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory_UI : MonoBehaviour
{
    [SerializeField] GameObject slot_UI;

    public Inventory inventory;
    public Transform itemsHolder;

    private void Start()
    {
        RefreshItems();
        inventory.OnItemsChanged += RefreshItems;
    }

    void RefreshItems()
    {
        foreach (Transform slot in itemsHolder)
        {
            Destroy(slot.gameObject);
        }

        for (int i = 0; i < inventory.GetItemSlots().Count; i++)
        {
            GameObject newSlot_UI = Instantiate(slot_UI, itemsHolder);
            newSlot_UI.GetComponent<ItemSlot_UI>()?.Initialize(inventory.GetItemSlots()[i]);
        }
    }
}
