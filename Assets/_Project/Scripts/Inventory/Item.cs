using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Item
{
    [HideInInspector] public Actor owner;
    public ItemSO data;
}
