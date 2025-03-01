using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySystem inventory;
    public InventorySlotUI[] slotUIs;

    public Transform slotContainer;
    private void Start()
    {
       
        slotUIs = slotContainer.GetComponentsInChildren<InventorySlotUI>();

      
        if (slotUIs.Length != inventory.slots.Length)
        {
            Debug.LogError("Количество UI-слотов не совпадает с инвентарем!");
        }

       
        for (int i = 0; i < slotUIs.Length; i++)
        {
            slotUIs[i].Setup(i, inventory);
        }

        RefreshUI();
    }

    public void RefreshUI()
    {
        for (int i = 0; i < slotUIs.Length; i++)
        {
            slotUIs[i].UpdateSlot();
        }
    }

    public void UnlockAllSlotsUI()
    {
        inventory.UnlockAdditionalSlots();
        RefreshUI();
    }
}
