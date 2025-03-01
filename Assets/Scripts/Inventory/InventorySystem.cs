using UnityEngine;




[CreateAssetMenu(fileName = "NewInventory", menuName = "Inventory/Inventory System")]
public class InventorySystem : ScriptableObject
{
    public InventorySlot[] slots = new InventorySlot[30];
    public int unlockedSlots = 15;
    public int unlockPrice = 100;
    public int playerCoins = 500;

  /*  private void OnEnable()
    {
        
        for (int i = 0; i < slots.Length; i++)
        {
            slots[i] = new InventorySlot();
        }
    }*/

    

    public void UnlockFirstSlots()
    {
        for (int i = 0; i < unlockedSlots; i++) 
        {
            slots[i].Unlock();
        }
         
    }


    public bool AddItem(ItemBase item, int amount)
    {
        foreach (var slot in slots)
        {
            if (slot.IsUnlocked && slot.AddItem(item, amount))
            {
                return true;
            }
        }
        return false;
    }

    public void RemoveItem(int slotIndex)
    {
        if (slotIndex >= 0 && slotIndex < slots.Length && slots[slotIndex].IsUnlocked)
        {
            slots[slotIndex].Clear();
        }
    }



    public bool UnlockAdditionalSlots()
    {
        
        if (playerCoins >= unlockPrice && unlockedSlots < slots.Length)
        {

            playerCoins -= unlockPrice;

         
            for (int i = unlockedSlots; i < unlockedSlots + 15 && i < slots.Length; i++)
            {
                slots[i].Unlock();
            }


            unlockedSlots += 15;

           
            return true;
        }
        else
        {
            
            Debug.LogError("Недостаточно монет для разблокировки слотов или все слоты уже разблокированы!");
            return false;
        }
    }

}