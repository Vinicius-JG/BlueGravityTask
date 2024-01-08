using System;
using UnityEngine;

[Serializable]
public class Item
{
    [HideInInspector] public Actor owner;
    public ItemSO data;
}
