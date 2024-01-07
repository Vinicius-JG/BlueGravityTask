using Animancer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentSystem : Inventory
{
    [Serializable]
    public struct EquipSlot
    {
        public SpriteRendererTextureSwap textureSwap;
        public ItemSO.Type type;
    }

    [SerializeField] EquipSlot[] equipSlots;

    private void Awake()
	{
        SetSlotsInventory();
		RefreshEquipments();
		OnItemsChanged += RefreshEquipments;
	}

	void RefreshEquipments()
	{
		foreach (EquipSlot equipSlot in equipSlots)
		{
            equipSlot.textureSwap.gameObject.SetActive(true);
            ItemSlot rightSlot = null;

            foreach (ItemSlot itemSlot in itemSlots)
            {
                if (itemSlot.itemSO != null && itemSlot.itemSO.type == equipSlot.type)
                {
                    rightSlot = itemSlot;
                    break;
                }
            }

            if(rightSlot != null)
            {
                equipSlot.textureSwap.Texture = rightSlot.itemSO.spriteSheet;

                if(rightSlot.itemSO.typeToDisableWhenEquipped != ItemSO.Type.None)
                {
                    EquipSlot equipSlotToDisable = equipSlots.ToList().Find(x => x.type == rightSlot.itemSO.typeToDisableWhenEquipped);
                    equipSlotToDisable.textureSwap.gameObject.SetActive(false);
                }
            }
            else
            {
                equipSlot.textureSwap.gameObject.SetActive(false);
            }

        }
    }
}
