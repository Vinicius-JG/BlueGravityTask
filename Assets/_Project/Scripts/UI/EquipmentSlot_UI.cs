using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EquipmentSlot_UI : ItemSlot_UI
{
    public EquipmentSystem equipmentSystem;

    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
    }
}
