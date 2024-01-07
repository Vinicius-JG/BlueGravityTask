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

        ItemSlot_UI itemSlot_UI = eventData.pointerDrag?.GetComponent<DragAndDrop_UI>().startParent.GetComponent<ItemSlot_UI>();

        if (itemSlot_UI != null)
        {
            equipmentSystem.EquipItem(item, requiredType);
        }
    }

    public override void Refresh()
    {
        base.Refresh();
        equipmentSystem.EquipItem(item, requiredType);
    }
}
