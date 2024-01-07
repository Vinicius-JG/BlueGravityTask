using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot_UI : MonoBehaviour, IDropHandler
{
    [HideInInspector] public Inventory inventory;
    public ItemSO item;
    public ItemSO.Type requiredType;
    [SerializeField] Image content;

    public void Initialize(ItemSO item, Inventory inventory)
    {
        this.item = item;
        this.inventory = inventory;
        content.transform.SetParent(transform);
        content.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
        content.GetComponent<CanvasGroup>().blocksRaycasts = true;
        content.sprite = item != null ? item.icon : null;
        content.gameObject.SetActive(item != null);
    }

    public virtual void OnDrop(PointerEventData eventData)
    {
        ItemSlot_UI itemSlot_UI = eventData.pointerDrag?.GetComponent<DragAndDrop_UI>().startParent.GetComponent<ItemSlot_UI>();

        if (itemSlot_UI != null)
        {
            if(requiredType == ItemSO.Type.None || requiredType == itemSlot_UI.item.type)
            {
                ItemSO temp = itemSlot_UI.item;
                itemSlot_UI.item = item;
                item = temp;
                Refresh();
                itemSlot_UI.Refresh();
            }
        }
    }

    public virtual void Refresh()
    {

    }
}
