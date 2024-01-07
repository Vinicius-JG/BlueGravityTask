using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "ScriptableObjects/Item")]
public class ItemSO : ScriptableObject
{
    public enum Type
    {
        None,
        Outfit,
        Hair,
        Hat
    }

    public string itemName;
    public Texture2D spriteSheet;
    public Sprite icon;
    public int price;
    public Type type;
    public Type typeToDisableWhenEquipped;
}
