using System.Collections.Generic;

public interface IInventoryView
{
    void DisplayInventory(IReadOnlyList<IItem> items);
}
