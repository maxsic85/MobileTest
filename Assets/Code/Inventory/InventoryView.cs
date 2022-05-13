using System.Collections.Generic;
using UnityEngine;
public class InventoryView : IInventoryView
{
    public void DisplayInventory(IReadOnlyList<IItem> items)
    {
        foreach (var item in items)
        {
            Debug.Log($"ID: {item.Id} Title {item.IInfo.Title}");
        }
    }
    public void Show()
    { 
    
    }

    public void Hide()
    { 
    
    }  
}
