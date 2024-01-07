using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot_UI : MonoBehaviour, IDropHandler
{
    [HideInInspector] public ItemSlot itemSlot;
    [SerializeField] Image content;

    public void Initialize(ItemSlot itemSlot)
    {
        this.itemSlot = itemSlot;
        content.transform.SetParent(transform);
        content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        content.GetComponent<CanvasGroup>().blocksRaycasts = true;
        content.sprite = itemSlot.item.data != null ? itemSlot.item.data.icon : null;
        content.gameObject.SetActive(itemSlot.item.data != null);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        ItemSlot_UI itemSlot_UI = eventData.pointerDrag?.GetComponent<DragAndDrop_UI>().startParent.GetComponent<ItemSlot_UI>();

        if (itemSlot_UI != null)
        {
            itemSlot.inventory.TrySwapItems(itemSlot_UI.itemSlot, this.itemSlot);
        }
    }
}
