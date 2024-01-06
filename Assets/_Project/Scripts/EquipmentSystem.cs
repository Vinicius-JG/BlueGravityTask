using Animancer;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
	[Serializable]
	private struct EquipmentSlot
	{
		public ItemSO.Type type;
        public ItemSO itemSO;
        public SpriteRendererTextureSwap textureSwap;
	}

	[SerializeField] EquipmentSlot[] equipmentSlots;

	private void Awake()
	{
		RefreshEquipments();
	}

	public void EquipItem(ItemSO item)
	{
		EquipmentSlot slot;

        foreach (EquipmentSlot equipmentSlot in equipmentSlots)
        {
			if(equipmentSlot.type == item.type)
			{
				slot = equipmentSlot;
				break;
            }
        }

		slot.itemSO = item;
		RefreshEquipments();
    }

	public void RemoveItem(ItemSO item)
	{
        EquipmentSlot slot;

        foreach (EquipmentSlot equipmentSlot in equipmentSlots)
        {
            if (equipmentSlot.itemSO == item)
            {
                slot = equipmentSlot;
                break;
            }
        }

        slot.itemSO = null;
        RefreshEquipments();
    }

	void RefreshEquipments()
	{
		foreach (EquipmentSlot equipmentSlot in equipmentSlots)
		{
			equipmentSlot.textureSwap.Texture = equipmentSlot.itemSO.spriteSheet;

            equipmentSlot.textureSwap.gameObject.SetActive(true);

            if (equipmentSlot.itemSO.typeToDisableWhenEquipped != ItemSO.Type.None)
			{
				EquipmentSlot slot = equipmentSlots.ToList().Find(x => x.type == equipmentSlot.itemSO.typeToDisableWhenEquipped);
				slot.textureSwap.gameObject.SetActive(false);
            }
        }
	}
}
