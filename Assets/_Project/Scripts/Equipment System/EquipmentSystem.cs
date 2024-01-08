using Animancer;
using System;
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
                if (itemSlot.item != null && itemSlot.item.data != null && itemSlot.item.data.type == equipSlot.type)
                {
                    rightSlot = itemSlot;
                    break;
                }
            }

            if(rightSlot != null)
            {
                equipSlot.textureSwap.Texture = rightSlot.item.data.spriteSheet;
            }
            else
            {
                equipSlot.textureSwap.gameObject.SetActive(false);
            }
        }

        CheckEquipsToDisable();
    }

    void CheckEquipsToDisable()
    {
        foreach (ItemSlot itemSlot in itemSlots)
        {
            if(itemSlot.item != null && itemSlot.item.data != null && itemSlot.item.data.typeToDisableWhenEquipped != ItemSO.Type.None)
            {
                equipSlots.ToList().Find(x => x.type == itemSlot.item.data.typeToDisableWhenEquipped).textureSwap.gameObject.SetActive(false);
            }
        }
    }

}
