using UnityEngine;




[CreateAssetMenu(fileName = "NewArmor", menuName = "Items/Armor")]
public class ArmorItem : ItemBase
{
    public int defense;
    private void Awake() => itemType = ItemType.Armor;
}
