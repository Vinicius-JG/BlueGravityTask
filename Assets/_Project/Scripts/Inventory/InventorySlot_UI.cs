using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class InventorySlot_UI : ItemSlot_UI
{
    public override void OnDrop(PointerEventData eventData)
    {
        base.OnDrop(eventData);
    }

    public override void Refresh()
    {
        base.Refresh();
        inventory.AddItem(item, transform.GetSiblingIndex());
    }
}
