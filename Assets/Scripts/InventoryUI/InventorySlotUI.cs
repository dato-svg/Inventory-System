using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlotUI : MonoBehaviour
{
    public Image icon;
    public Image blockIcon;
    public TextMeshProUGUI countText;
    public int index;
    public InventorySystem inventory;

  
    

    public void Setup(int i, InventorySystem inv)
    {
        index = i;
        inventory = inv;
    }

    public void UpdateSlot()
    {
        var slot = inventory.slots[index];

        if (slot.IsUnlocked)
        { 
             blockIcon.enabled = false;
        }
        else
        {       
             blockIcon.enabled = true;
        }


        if (slot.item != null)
        {
            icon.sprite = slot.item.icon;
            icon.enabled = true;
            countText.text = slot.count > 1 ? slot.count.ToString() : "";
        }
        else
        {
            icon.enabled = false;
            countText.text = "";
        }
    }
}
