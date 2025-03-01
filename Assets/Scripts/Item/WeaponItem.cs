using UnityEngine;



[CreateAssetMenu(fileName = "NewWeapon", menuName = "Items/Weapon")]
public class WeaponItem : ItemBase
{
    public int attackPower;
    private void Awake() => itemType = ItemType.Weapon;
}