using UnityEngine;



[CreateAssetMenu(fileName = "NewAmmo", menuName = "Items/Ammo")]
public class AmmoItem : ItemBase
{
    private void Awake() => itemType = ItemType.Ammo;
}