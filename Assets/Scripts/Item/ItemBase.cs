using UnityEngine;

public abstract class ItemBase : ScriptableObject
{
    public string itemName;
    public float weight;
    public Sprite icon;
    public ItemType itemType;
    public int maxStack = 1;
}



public enum ItemType 
{   
    Ammo,
    Weapon,
    Armor 
}
