using Animancer;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;
using static UnityEngine.Rendering.VolumeComponent;

public class Inventory : MonoBehaviour
{
    [SerializeField] List<ItemSO> items;
    public Action OnItemsChanged;

    public void AddItem(ItemSO item)
    {
        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == null)
            {
                items[i] = item;
                break;
            }
        }

        OnItemsChanged?.Invoke();
    }

    public void AddItem(ItemSO item, int position)
    {
        items[position] = item;
        OnItemsChanged?.Invoke();
    }

    public void RemoveItem(ItemSO item)
    {
        items.Remove(item);
        OnItemsChanged?.Invoke();
    }

    public void SwapItems(int firstIndex, int secondIndex)
    {
        ItemSO temp = items[firstIndex];

        items[firstIndex] = items[secondIndex];
        items[secondIndex] = temp;
        OnItemsChanged?.Invoke();
    }

    public List<ItemSO> GetItems()
    {
        return items;
    }
}
