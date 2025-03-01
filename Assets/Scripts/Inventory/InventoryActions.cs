using System.Linq;
using UnityEngine;

public class InventoryActions : MonoBehaviour
{
    public InventorySystem inventory;
    public InventoryUI inventoryUI;
    public ItemBase[] itemWeapon;
    public ItemBase[] itemHead;
    public ItemBase[] itemTorso;
    public ItemBase[] itemAmmo;


    private void Start()
    {
        inventory.UnlockFirstSlots();
    }
    public void Shoot()
    {
        var ammoSlots = inventory.slots.Where(slot => slot.item?.itemType == ItemType.Ammo).ToList();

        if (ammoSlots.Count > 0)
        {
            var randomSlot = ammoSlots[Random.Range(0, ammoSlots.Count)];

            randomSlot.count--;

            if (randomSlot.count <= 0)
            {
                randomSlot.Clear();
            }

            inventoryUI.RefreshUI();
        }
        else
        {
           
            Debug.LogError("Нет патронов в инвентаре!");
        }
    }


    public void AddAmmo()
    {
        foreach (var item in itemAmmo)
        {
            if (item.itemType == ItemType.Ammo)
            {
                inventory.AddItem(item, item.maxStack);
                
            }
                
        }
        inventoryUI.RefreshUI();
    }

    public void AddItems()
    {
       
        AddRandomItem(itemWeapon); 
        AddRandomItem(itemHead); 
        AddRandomItem(itemTorso); 

      
        inventoryUI.RefreshUI();
    }

    
    private void AddRandomItem(ItemBase[] items)
    {
        
        if (items.Length > 0)
        {
            
            ItemBase randomItem = items[Random.Range(0, items.Length)];

           
            inventory.AddItem(randomItem, 1);
        }
    }

    public void RemoveItem()
    {
        bool itemRemoved = false;


        if (inventory.slots.All(slot => slot.item == null))
        {
            Debug.LogError("Инвентарь пуст");
            return;
        }
       
        while (!itemRemoved)
        {
           
            int slotIndex = Random.Range(0, inventory.slots.Length);

           
            if (inventory.slots[slotIndex].item != null)
            {
                inventory.RemoveItem(slotIndex);
                inventoryUI.RefreshUI(); 
                itemRemoved = true;
                return;
            }
        }
   
    }

    public void UnLockAll()
    {
        inventoryUI.UnlockAllSlotsUI();
    }

}
