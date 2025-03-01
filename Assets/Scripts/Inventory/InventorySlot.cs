


[System.Serializable]
public class InventorySlot
{
    public ItemBase item;
    public int count;
    public bool IsUnlocked  = false;


    public bool AddItem(ItemBase newItem, int amount)
    {
        if (item == newItem && count + amount <= item.maxStack)
        {
            count += amount;
            return true;
        }
        if (item == null)
        {
            item = newItem;
            count = amount;
            return true;
        }
        return false;
    }

    public void Clear()
    {
        item = null;
        count = 0;
    }

    public void Unlock()
    {
       IsUnlocked = true;
    }
}
