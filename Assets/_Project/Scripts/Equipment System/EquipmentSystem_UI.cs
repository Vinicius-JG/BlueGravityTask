using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem_UI : MonoBehaviour
{
    [SerializeField] EquipmentSystem inventory;
    [SerializeField] List<ItemSlot_UI> itemSlots_UI;

    private void Start()
    {
        RefreshEquipments();
        inventory.OnItemsChanged += RefreshEquipments;
    }

    void RefreshEquipments()
    {
        for (int i = 0; i < itemSlots_UI.Count; i++)
        {
            itemSlots_UI[i].GetComponent<ItemSlot_UI>()?.Initialize(inventory.GetItemSlots()[i]);
        }
    }
}
