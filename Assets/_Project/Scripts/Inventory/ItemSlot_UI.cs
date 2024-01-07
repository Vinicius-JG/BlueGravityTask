using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot_UI : MonoBehaviour, IDropHandler
{
    Inventory_UI inventory_UI;
    public ItemSO item;
    [SerializeField] Image content;

    public void Initialize(ItemSO item, Inventory_UI inventory_UI)
    {
        this.item = item;
        this.inventory_UI = inventory_UI;
        content.transform.SetParent(transform);
        content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        content.GetComponent<CanvasGroup>().blocksRaycasts = true;
        content.sprite = item != null ? item.icon : null;
        content.gameObject.SetActive(item != null);
    }

    public void OnDrop(PointerEventData eventData)
    {
        ItemSlot_UI itemSlot_UI = eventData.pointerDrag?.GetComponent<DragAndDrop_UI>().startParent.GetComponent<ItemSlot_UI>();

        if (itemSlot_UI != null)
            inventory_UI.inventory.SwapItems(transform.GetSiblingIndex(), itemSlot_UI.transform.GetSiblingIndex());
    }
}
