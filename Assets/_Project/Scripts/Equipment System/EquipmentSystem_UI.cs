using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem_UI : MonoBehaviour
{
    public EquipmentSystem equipmentSystem;
    [SerializeField] List<EquipmentSlot_UI> equipmentSlots_UI;

    private void Start()
    {
        RefreshEquipments();
        equipmentSystem.OnEquipsChanged += RefreshEquipments;
    }

    void RefreshEquipments()
    {
        foreach (var slot_UI in equipmentSlots_UI)
        {
            EquipmentSystem.EquipmentSlot[] slots = equipmentSystem.GetEquipmentSlots();

            for (int i = 0; i < slots.Length; i++)
            {
                if (slots[i].type == slot_UI.requiredType)
                    slot_UI.Initialize(slots[i].itemSO, null);
            }
        }
    }
}
