using UnityEngine;

public class InventoryUI : MonoBehaviour
{
    public InventorySystem inventory;
    public InventorySlotUI[] slotUIs;

    public Transform slotContainer;
    private void Awake()
    {
       
        if (inventory == null)
        {
            Debug.LogError("Inventory �� �������� � Inspector!");
            return;
        }

       
        inventory.UnlockFirstSlots();

      
        slotUIs = slotContainer.GetComponentsInChildren<InventorySlotUI>();

      
        if (slotUIs.Length != inventory.slots.Length)
        {
            Debug.LogError("���������� UI-������ �� ��������� � ����������� ������ � ���������!");
        }

     
        for (int i = 0; i < slotUIs.Length; i++)
        {
            slotUIs[i].Setup(i, inventory);
        }

        RefreshUI();
    }



        public void Start()
        {
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
